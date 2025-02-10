using Application.Features.Auths.Authentication.Password;
using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Entities;
using Domain.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class AuthenticationRepository : RepositoryBase<User, long, MyDbContext>, IAuthenticationRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository;
        private readonly ErrorCode _errorCodes;
        private readonly IUserRepository _iUserRepository;

        public AuthenticationRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository,
            IUserRepository iUserRepository, IOptions<ErrorCode> errorCodes)
            : base(dbContext, unitOfWork)
        {
            _iEncryptionRepository = iEncryptionRepository;
            _iUserRepository = iUserRepository;
            _errorCodes = errorCodes.Value;
        }

        public string CheckPassword(SignInDto model, string securityStamp)
        {
            return _iEncryptionRepository.EncryptPassword(model.Password, securityStamp);
        }

        public async Task<IActionResult> ChangePassword(int userId, PasswordDto model)
        {
            try
            {
                var validator = new PasswordValidator();
                var check = await validator.ValidateAsync(model);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var user = await _iUserRepository.GetByIdAsync(userId);
                if (user == null) return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound ?? "NotFound", "User Does Not Exist");
                if (user.IsDeleted == true) return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden ?? "Forbidden", "User Has Blocked");
                var checkPassword = _iEncryptionRepository.EncryptPassword(model.CurrentPassword, user.SecurityStamp);
                if (user.PasswordHash != checkPassword) return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound ?? "NotFound", "Incorrect Password");
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = _iEncryptionRepository.EncryptPassword(model.ConfirmPassword, user.SecurityStamp);
                await _iUserRepository.UpdateAsync(user);
                return JsonUtil.Success("Change Password Success");
            }
            catch (UnauthorizedAccessException e)
            {
                return JsonUtil.Error(StatusCodes.Status401Unauthorized, _errorCodes?.Status401?.Unauthorized ?? "Unauthorized", e.Message);
            }
        }
    }
}
