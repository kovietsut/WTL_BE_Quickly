using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IAuthenticationRepository : IRepositoryBase<User, long>
    {
        Task<long> SignUp(SignUpDto model);
        string CheckPassword(SignInDto model, string securityStamp);
        Task<IActionResult> UpdateEmailUser(int userId, UpdateEmailDto model);
        Task<IActionResult> ChangePassword(int userId, PasswordDto model);
    }
}
