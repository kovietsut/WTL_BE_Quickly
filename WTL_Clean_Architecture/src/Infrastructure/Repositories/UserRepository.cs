using Application.Features.Users.Commands;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Infrastructure.Configurations;
using Infrastructure.Utils;
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

        public List<string> GetListEmail(List<long?> listIds)
        {
            var emails = FindAll().Where(x => listIds.Contains(x.Id)).Select(x => x.Email).ToList();
            return emails;
        }

        public Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText, int? roleId)
        {
            try
            {
                pageNumber ??= 1; pageSize ??= 10;
                var list = FindAll(false, x => x.Role).Where(x => x.IsDeleted == true && (x.RoleId == roleId || roleId == null) &&
                (searchText == null || x.FullName.Contains(searchText.Trim()) || x.PhoneNumber.Contains(searchText.Trim())
                    || x.Address.Contains(searchText.Trim()) || x.Email.Contains(searchText.Trim())))
                    .Select(x => new
                    {
                        UserId = x.Id,
                        x.IsDeleted,
                        x.FullName,
                        x.Email,
                        x.PhoneNumber,
                        x.Avatar,
                        x.Gender,
                        x.Address,
                        x.RoleId,
                        RoleName = x.Role.Name
                    });
                var listData = list.Skip(((int)pageNumber - 1) * (int)pageSize)
                    .Take((int)pageSize).OrderByDescending(x => x.UserId).ToList();
                if (list != null)
                {
                    var totalRecords = list.Count();
                    return Task.FromResult<IActionResult>(JsonUtil.Success(listData, dataCount: totalRecords));
                }
                return Task.FromResult<IActionResult>(JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Empty List Data"));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(JsonUtil.Error(StatusCodes.Status401Unauthorized, _errorCodes?.Status401?.Unauthorized, ex.Message));
            }
        }

        public Task<User> GetUserByEmail(string email) =>
            FindByCondition(x => x.Email.Equals(email)).SingleOrDefaultAsync();

        public Task<User> GetUserById(long id) =>
            FindByCondition(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<IActionResult> GetUser(long userId)
        {
            var user = await GetUserById(userId);
            if (user == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "User does not exist");
            }
            var result = new
            {
                user.Id,
                user.IsDeleted,
                user.RoleId,
                user.Email,
                user.FullName,
                user.PhoneNumber,
                user.Address,
                user.Gender,
                user.Avatar,
                user.CreatedAt,
                user.UpdatedAt
            };
            return JsonUtil.Success(result);
        }

        public async Task<IActionResult> CreateUserAsync(CreateUserDto model)
        {
            try
            {
                var validator = new CreateUserValidator();
                var check = await validator.ValidateAsync(model);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation, check.Errors);
                }
                var userByEmail = await GetUserByEmail(model.Email);
                if (userByEmail != null && userByEmail.Email != null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Email existed");
                }
                var userByPhoneNumber = FindByCondition(x => x.PhoneNumber != null && x.PhoneNumber.Equals(model.PhoneNumber.Trim())).FirstOrDefault();
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
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation, check.Errors);
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
