using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, string>
    {
        Task<User?> GetUserById(string id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByPhoneNumber(string? phoneNumber);
        Task<List<User>> GetList(int? pageNumber, int? pageSize, string? searchText, string? roleId);
        Task<User> CreateUserAsync(CreateUserDto model);
        Task<User> UpdateUserAsync(string userId, UpdateUserDto model);
        Task<User?> DeleteUserAsync(string id);
    }
}
