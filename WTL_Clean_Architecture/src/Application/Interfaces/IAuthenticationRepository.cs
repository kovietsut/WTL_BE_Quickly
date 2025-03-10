using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthenticationRepository : IRepositoryBase<User, long>
    {
        string CheckPassword(SignInDto model, string securityStamp);
        long GetUserId();
    }
}
