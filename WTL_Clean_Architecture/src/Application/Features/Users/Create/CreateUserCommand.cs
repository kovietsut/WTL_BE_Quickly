using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.Create
{
    public class CreateUserCommand : IRequest<IActionResult>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string RePassword { get; set; }
        public long RoleId { get; set; }
        public string? FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }

    public class CreateUserCommmandHandler(IUserRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateUserCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateUserCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createUserDto = new CreateUserDto
                {
                    Email = query.Email,
                    Password = query.Password,
                    RePassword = query.RePassword,
                    RoleId = query.RoleId,
                    FullName = query.FullName,
                    PhoneNumber = query.PhoneNumber,
                    Address = query.Address,
                    Gender = query.Gender
                };
                var validator = new CreateUserValidator();
                var check = await validator.ValidateAsync(createUserDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var userByEmail = await repository.GetUserByEmail(query.Email);
                if (userByEmail != null && userByEmail.Email != null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Email existed");
                }
                var userByPhoneNumber = await repository.GetUserByPhoneNumber(query.PhoneNumber);
                if (userByPhoneNumber != null && userByPhoneNumber.PhoneNumber != null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Phone number existed");
                }
                var user = await repository.CreateUserAsync(createUserDto);
                return JsonUtil.Success(user.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
