using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, long>
    {
        List<string> GetListEmail(List<long?> listIds);
        Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(long id);
        Task<IActionResult> GetUser(long userId);
        Task<IActionResult> CreateUserAsync(CreateUserDto model);
        Task<IActionResult> UpdateUserAsync(int userId, UpdateUserDto model);
        Task<IActionResult> DeleteUserAsync(long id);
    }
}
