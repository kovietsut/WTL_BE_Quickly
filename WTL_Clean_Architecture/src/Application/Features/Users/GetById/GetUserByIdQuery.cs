using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.GetById
{
    public class GetUserByIdQuery(string id) : IRequest<IActionResult>
    {
        public string Id { get; private set; } = id;
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetUserByIdQueryHandler(IUserRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserById(query.Id);
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
    }
}
