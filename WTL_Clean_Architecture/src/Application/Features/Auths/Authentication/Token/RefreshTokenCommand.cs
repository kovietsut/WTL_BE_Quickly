using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Features.Auths.Authentication.Token
{
    public class RefreshTokenCommand : IRequest<IActionResult>
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }

    public class RefreshTokenCommandHandler(IUserRepository repository, ITokenRepository tokenRepository, IOptions<ErrorCode> errorCodes, IConfiguration configuration) : IRequestHandler<RefreshTokenCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(RefreshTokenCommand query, CancellationToken cancellationToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = configuration["Jwt:Secret"];
            if (string.IsNullOrEmpty(secretKey))
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, "Secret key is missing");
            }
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(query.AccessToken, tokenValidateParam, out var validatedToken);
                //check 2: Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Invalid token");
                    }
                }
                //check 3: Check accessToken expire
                var utcExpireDate = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)!.Value;
                var expireDate = tokenRepository.ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.Now)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Access token has not expired yet");
                }
                //check 4: Check refreshtoken exist in DB
                var storedToken = await tokenRepository.GetTokenByRefreshToken(query.RefreshToken);
                if (storedToken == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Refresh token does not exist");
                }
                //check 5: check refreshToken used or revoked?
                if (storedToken.RefreshTokenExpiration <= DateTime.Now)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Refresh token is used");
                }
                if (storedToken.IsRevoked)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Refresh token has been revoked");
                }
                //check 6: AccessToken id == JwtId in RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (storedToken.JwtId != jti)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Token doesn't match");
                }
                //Update token is used
                storedToken.IsDeleted = true;
                await tokenRepository.UpdateAsync(storedToken);
                //Create new token
                var user = await repository.GetUserById(storedToken.UserId);
                if(user == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "User not found");
                }
                var userModel = new UserTokenDto()
                {
                    UserId = user.Id,
                    Email = user.Email,
                };
                var token = await tokenRepository.GenerateToken(userModel);
                return JsonUtil.Success(token);
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, e.Message);
            }
        }
    }
}
