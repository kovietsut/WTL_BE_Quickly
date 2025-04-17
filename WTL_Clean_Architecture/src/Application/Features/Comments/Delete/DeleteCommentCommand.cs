using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Comments.Delete
{
    public class DeleteCommentCommand : IRequest<IActionResult>
    {
        public required long Id { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, IActionResult>
    {
        private readonly ICommentRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteCommentCommandHandler(
            ICommentRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.DeleteCommentAsync(request.Id);
                
                if (!result)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }
                
                return JsonUtil.Success(new { Id = request.Id });
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
} 