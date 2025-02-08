using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;

        public UserController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            return await _iUserRepository.GetUser(userId);
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId)
        {
            return await _iUserRepository.GetList(pageNumber, pageSize, searchText, roleId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto model)
        {
            return await _iUserRepository.CreateUserAsync(model);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(int userId, [FromBody] UpdateUserDto model)
        {
            return await _iUserRepository.UpdateUserAsync(userId, model);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            return await _iUserRepository.DeleteUserAsync(userId);
        }
    }
}
