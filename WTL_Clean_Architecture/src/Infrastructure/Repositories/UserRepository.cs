using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, string, MyDbContext>, IUserRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository;

        public UserRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository)
            : base(dbContext, unitOfWork)
        {
            _iEncryptionRepository = iEncryptionRepository;
        }

        public async Task<User?> GetUserById(string id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetUserByIdSpecification(id);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var query = FindByCondition(x => x.Email == email);
            var specification = new GetUserByEmailSpecification(email);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<User?> GetUserByPhoneNumber(string? phoneNumber)
        {
            if (phoneNumber == null) return null;
            var query = FindByCondition(x => x.PhoneNumber == phoneNumber);
            var specification = new GetUserByPhoneNumberSpecification(phoneNumber);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetList(int? pageNumber, int? pageSize, string? searchText, string? roleId)
        {
            var specification = new GetListUsersSpecification(pageNumber, pageSize, searchText, roleId);
            var query = FindBySpecification(specification);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<User> CreateUserAsync(CreateUserDto model)
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                RoleId = model.RoleId,
                SecurityStamp = Guid.NewGuid().ToString(),
                CreatedAt = DateTimeOffset.UtcNow,
                Email = model.Email.Trim(),
                FullName = model.FullName != null ? model.FullName.Trim() : model.FullName,
                PhoneNumber = model.PhoneNumber != null ? model.PhoneNumber.Trim() : model.PhoneNumber,
                Address = model.Address != null ? model.Address.Trim() : model.Address,
                Gender = model.Gender
            };
            user.PasswordHash = _iEncryptionRepository.EncryptPassword(model.Password, user.SecurityStamp);
            await CreateAsync(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(string userId, UpdateUserDto model)
        {
            var currentUser = await GetByIdAsync(userId) ?? throw new ArgumentNullException(nameof(userId), "User not found");
            currentUser.UpdatedAt = DateTimeOffset.UtcNow;
            currentUser.Email = model.Email.Trim();
            currentUser.FullName = model.FullName != null ? model.FullName.Trim() : model.FullName;
            currentUser.PhoneNumber = model.PhoneNumber != null ? model.PhoneNumber.Trim() : model.PhoneNumber;
            currentUser.Address = model.Address != null ? model.Address.Trim() : model.Address;
            currentUser.Gender = model.Gender;
            await UpdateAsync(currentUser);
            return currentUser;
        }

        public async Task<User?> DeleteUserAsync(string id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await UpdateAsync(user);
            }
            return user;
        }
    }
}
