using Application.Features.Auths.Login;
using Application.Features.Users.Create;
using Application.Features.Users.Update;
using Application.Models;
using Application.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserDto model)
        {
            var query = new CreateUserCommand()
            {
                Email = model.Email,
                Password = model.Password,
                RoleId = model.RoleId,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Gender = model.Gender
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto model)
        {
            var query = new LoginCommand()
            {
                Email = model.Email,
                Password = model.Password
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RenewToken([FromBody] TokenDto model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);
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
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = _iTokenRepository.ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.Now)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Access token has not expired yet");
                }
                //check 4: Check refreshtoken exist in DB
                var storedToken = await _iTokenRepository.GetTokenByRefreshToken(model.RefreshToken);
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
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Token doesn't match");
                }
                //Update token is used
                storedToken.IsDeleted = true;
                await _iTokenRepository.UpdateAsync(storedToken);
                //Create new token
                var user = await _iUserRepository.GetUserById(storedToken.UserId);
                var userModel = new UserTokenDto()
                {
                    UserId = user.Id,
                    Email = user.Email,
                };
                var token = await _iTokenRepository.GenerateToken(userModel);
                return JsonUtil.Success(token);
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, e.Message);
            }
        }


        [HttpPut("{userId}/profile")]
        public async Task<IActionResult> UpdateEmail(int userId, [FromBody] UpdateUserDto model)
        {
            var query = new UpdateUserCommand()
            {
                Id = userId,
                Email = model.Email,
                RoleId = model.RoleId,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Gender = model.Gender
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{userId}/change-password")]
        public async Task<IActionResult> ChangePassword(int userId, [FromBody] PasswordDto model)
        {
            try
            {
                return await _iAuthRepository.ChangePassword(userId, model);
            }
            catch (Exception e)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, e.Message);
            }
        }
    }
}