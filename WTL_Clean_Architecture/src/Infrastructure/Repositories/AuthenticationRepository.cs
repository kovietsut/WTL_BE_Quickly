using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class AuthenticationRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository,
        IHttpContextAccessor httpContextAccessor
        ) : RepositoryBase<User, long, MyDbContext>(dbContext, unitOfWork), IAuthenticationRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository = iEncryptionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string CheckPassword(SignInDto model, string securityStamp)
        {
            return _iEncryptionRepository.EncryptPassword(model.Password, securityStamp);
        }

        public long GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value;
            return long.Parse(user);
        }
    }
}
