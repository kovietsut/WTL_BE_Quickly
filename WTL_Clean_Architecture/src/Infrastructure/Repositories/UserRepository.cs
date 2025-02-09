using Application.Features.Users.Create;
using Application.Features.Users.Update;
using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, long, MyDbContext>, IUserRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository;
        private readonly ErrorCode _errorCodes;

        public UserRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository,
            IOptions<ErrorCode> errorCodes)
            : base(dbContext, unitOfWork)
        {
            _iEncryptionRepository = iEncryptionRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<User?> GetUserById(long id)
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

        public async Task<List<User>> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId)
        {
            var specification = new GetListUsersSpecification(pageNumber, pageSize, searchText, roleId);
            return await SpecificationQueryBuilder.GetQuery(FindAll(), specification).ToListAsync();
        }

        public async Task<IActionResult> CreateUserAsync(CreateUserDto model)
        {
            try
            {
                var validator = new CreateUserValidator();
                var check = await validator.ValidateAsync(model);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var userByEmail = await GetUserByEmail(model.Email);
                if (userByEmail != null && userByEmail.Email != null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Email existed");
                }
                var userByPhoneNumber = FindByCondition(x => !string.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.Equals(model.PhoneNumber.Trim())).FirstOrDefault();
                if (userByPhoneNumber != null && userByPhoneNumber.PhoneNumber != null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Phone number existed");
                }
                var user = new User()
                {
                    IsDeleted = true,
                    RoleId = model.RoleId,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    Email = model.Email.Trim(),
                    FullName = model.FullName != null ? model.FullName.Trim() : model.FullName,
                    PhoneNumber = model.PhoneNumber != null ? model.PhoneNumber.Trim() : model.PhoneNumber,
                    Address = model.Address != null ? model.Address.Trim() : model.Address,
                    Gender = model.Gender
                };
                user.PasswordHash = _iEncryptionRepository.EncryptPassword(model.Password, user.SecurityStamp);
                await CreateAsync(user);
                return JsonUtil.Success(user);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }

        public async Task<IActionResult> UpdateUserAsync(int userId, UpdateUserDto model)
        {
            try
            {
                var validator = new UpdateUserValidator();
                var check = await validator.ValidateAsync(model);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var currentUser = await GetByIdAsync(userId);
                if (currentUser == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "User does not exist");
                }
                var userByEmail = await GetUserByEmail(model.Email);
                if (userByEmail != null && currentUser.Email != userByEmail.Email)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Email existed");
                }
                var userByPhoneNumber = FindByCondition(x => x.PhoneNumber != null && x.PhoneNumber.Equals(model.PhoneNumber.Trim())).FirstOrDefault();
                if (userByPhoneNumber != null && currentUser.PhoneNumber != userByPhoneNumber.PhoneNumber)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Phone number existed");
                }
                if (currentUser.RoleId == 1)
                {
                    currentUser.RoleId = model.RoleId;
                }
                currentUser.UpdatedAt = DateTime.Now;
                currentUser.Email = model.Email.Trim();
                currentUser.FullName = model.FullName != null ? model.FullName.Trim() : model.FullName;
                currentUser.PhoneNumber = model.PhoneNumber != null ? model.PhoneNumber.Trim() : model.PhoneNumber;
                currentUser.Address = model.Address != null ? model.Address.Trim() : model.Address;
                currentUser.Gender = model.Gender;
                await UpdateAsync(currentUser);
                return JsonUtil.Success(currentUser.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }

        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await UpdateAsync(user);
            }
            return JsonUtil.Success(id);
        }
    }
}
