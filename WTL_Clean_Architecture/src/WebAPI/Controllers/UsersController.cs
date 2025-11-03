using Application.Features.Users.Create;
using Application.Features.Users.Delete;
using Application.Features.Users.GetById;
using Application.Features.Users.GetList;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText, string? roleId)
        {
            var query = new GetListUserQuery(pageNumber, pageSize, searchText, roleId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto model)
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

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(string userId, [FromBody] UpdateUserDto model)
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            var query = new DeleteUserCommand(userId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}


