using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.Delete
{
    public class DeleteUserCommand(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteUserCommandHandler(IUserRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteUserCommand query, CancellationToken cancellationToken)
        {
            var user = await _repository.DeleteUserAsync(query.Id);
            if (user == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "User does not exist");
            }
            return JsonUtil.Success(user.Id);
        }
    }
}
