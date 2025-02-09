using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, long>
    {
        Task<User?> GetUserById(long id);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId);
        Task<IActionResult> CreateUserAsync(CreateUserDto model);
        Task<IActionResult> UpdateUserAsync(int userId, UpdateUserDto model);
        Task<IActionResult> DeleteUserAsync(long id);
    }
}
