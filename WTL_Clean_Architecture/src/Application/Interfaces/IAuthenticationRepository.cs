using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthenticationRepository : IRepositoryBase<User, string>
    {
        string CheckPassword(SignInDto model, string securityStamp);
        string GetUserId();
    }
}
