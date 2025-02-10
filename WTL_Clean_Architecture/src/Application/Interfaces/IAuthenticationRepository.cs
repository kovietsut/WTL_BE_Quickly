using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IAuthenticationRepository : IRepositoryBase<User, long>
    {
        string CheckPassword(SignInDto model, string securityStamp);
        Task<IActionResult> ChangePassword(int userId, PasswordDto model);
    }
}
