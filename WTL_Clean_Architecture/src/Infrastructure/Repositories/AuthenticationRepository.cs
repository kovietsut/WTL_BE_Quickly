using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;

namespace Infrastructure.Repositories
{
    public class AuthenticationRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository) : RepositoryBase<User, long, MyDbContext>(dbContext, unitOfWork), IAuthenticationRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository = iEncryptionRepository;

        public string CheckPassword(SignInDto model, string securityStamp)
        {
            return _iEncryptionRepository.EncryptPassword(model.Password, securityStamp);
        }
    }
}
