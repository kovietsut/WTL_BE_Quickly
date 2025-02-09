using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, long>
    {
        Task<User?> GetUserById(long id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByPhoneNumber(string phoneNumber);
        Task<List<User>> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId);
        Task<User> CreateUserAsync(CreateUserDto model);
        Task<User> UpdateUserAsync(long userId, UpdateUserDto model);
        Task<User?> DeleteUserAsync(long id);
    }
}
