using Application.Features.Auths.Authentication.Login;
using Application.Features.Auths.Authentication.Password;
using Application.Features.Auths.Authentication.Token;
using Application.Features.Users.Create;
using Application.Features.Users.Update;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserDto model)
        {
            var query = new CreateUserCommand()
            {
                Email = model.Email,
                Password = model.Password,
                RePassword = model.RePassword,
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
            var query = new RefreshTokenCommand()
            {
                AccessToken = model.AccessToken,
                RefreshToken = model.RefreshToken
            };
            var result = await _mediator.Send(query);
            return result;
        }


        [HttpPut("{userId}/profile")]
        public async Task<IActionResult> UpdateEmail(string userId, [FromBody] UpdateUserDto model)
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
        public async Task<IActionResult> ChangePassword(string userId, [FromBody] PasswordDto model)
        {
            var query = new ChangePasswordCommand()
            {
                UserId = userId,
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword,
                ConfirmPassword = model.ConfirmPassword
            };
            var result = await _mediator.Send(query);
            return result;
        }
    }
}