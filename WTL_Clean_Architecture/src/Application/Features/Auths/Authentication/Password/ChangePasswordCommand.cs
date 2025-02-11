using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Auths.Authentication.Password
{
    public class ChangePasswordCommand : IRequest<IActionResult>
    {
        public required long UserId { get; set; }
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    public class ChangePasswordCommandHandler(IOptions<ErrorCode> errorCodes, IUserRepository iUserRepository, IEncryptionRepository iEncryptionRepository) : IRequestHandler<ChangePasswordCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(ChangePasswordCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var passwordDto = new PasswordDto
                {
                    CurrentPassword = query.CurrentPassword,
                    NewPassword = query.NewPassword,
                    ConfirmPassword = query.ConfirmPassword,
                };
                var validator = new PasswordValidator();
                var check = await validator.ValidateAsync(passwordDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var user = await iUserRepository.GetByIdAsync(query.UserId);
                if (user == null) return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound ?? "NotFound", "User Does Not Exist");
                if (user.IsDeleted == true) return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden ?? "Forbidden", "User Has Blocked");
                var checkPassword = iEncryptionRepository.EncryptPassword(query.CurrentPassword, user.SecurityStamp);
                if (user.PasswordHash != checkPassword) return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound ?? "NotFound", "Incorrect Password");
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = iEncryptionRepository.EncryptPassword(query.ConfirmPassword, user.SecurityStamp);
                await iUserRepository.UpdateAsync(user);
                return JsonUtil.Success("Change Password Success");
            }
            catch (UnauthorizedAccessException e)
            {
                return JsonUtil.Error(StatusCodes.Status401Unauthorized, _errorCodes?.Status401?.Unauthorized ?? "Unauthorized", e.Message);
            }
        }
    }
}
