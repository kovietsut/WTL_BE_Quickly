using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Auths.Authentication.Login
{
    public class LoginCommand : IRequest<IActionResult>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class LoginCommmandHandler(IUserRepository repository, IAuthenticationRepository authenticationRepository,
        ITokenRepository tokenRepository, IHttpContextAccessor httpContextAccessor, IOptions<ErrorCode> errorCodes) : IRequestHandler<LoginCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(LoginCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createUserDto = new SignInDto
                {
                    Email = query.Email,
                    Password = query.Password,
                };
                var user = await repository.GetUserByEmail(query.Email);
                if (user == null || user.SecurityStamp == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Incorrect Username or Password");
                }
                var checkPass = authenticationRepository.CheckPassword(createUserDto, user.SecurityStamp);
                if (checkPass != user.PasswordHash)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Incorrect Username or Password");
                }
                var userToken = new UserTokenDto()
                {
                    UserId = user.Id,
                    Email = user.Email,
                };
                return JsonUtil.Success(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FullName,
                    TokenData = await tokenRepository.GenerateToken(userToken)
                });
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
