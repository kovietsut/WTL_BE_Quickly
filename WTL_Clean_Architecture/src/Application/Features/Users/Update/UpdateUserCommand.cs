using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.Update
{
    public class UpdateUserCommand : IRequest<IActionResult>
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required string RoleId { get; set; }
        public string? FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }

    public class UpdateUserCommmandHandler : IRequestHandler<UpdateUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly ErrorCode _errorCodes;

        public UpdateUserCommmandHandler(IUserRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateUserCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var updateUserDto = new UpdateUserDto
                {
                    Email = query.Email,
                    RoleId = query.RoleId,
                    FullName = query.FullName,
                    PhoneNumber = query.PhoneNumber,
                    Address = query.Address,
                    Gender = query.Gender
                };
                var currentUser = await _repository.GetByIdAsync(query.Id);
                if (currentUser == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "User does not exist");
                }

                var userByEmail = await _repository.GetUserByEmail(query.Email);
                if (userByEmail != null && userByEmail.Id != query.Id)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "Email already exists for another user");
                }

                var userByPhoneNumber = await _repository.GetUserByPhoneNumber(query.PhoneNumber);
                if (userByPhoneNumber != null && userByPhoneNumber.Id != query.Id)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "Phone number already exists for another user");
                }
                
                var user = await _repository.UpdateUserAsync(query.Id, updateUserDto);
                return JsonUtil.Success(user.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
