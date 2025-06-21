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
        public required string Id { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, IActionResult>
    {
        private readonly ICommentRepository _repository;
        private readonly IAuthenticationRepository _authRepository;
        private readonly ErrorCode _errorCodes;

        public DeleteCommentCommandHandler(
            ICommentRepository repository,
            IAuthenticationRepository authRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _authRepository = authRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the comment to check ownership
                var comment = await _repository.GetCommendByIdAsync(request.Id);
                if (comment == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }

                // Get the current user ID from the authentication repository
                var currentUserId = _authRepository.GetUserId();

                // Check if the current user is the creator of the comment
                if (comment.UserId != currentUserId)
                {
                    return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden, "You do not have permission to delete this comment");
                }
                
                // Delete the parent comment
                var result = await _repository.DeleteCommentAsync(request.Id);
                
                if (!result)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }
                
                // If this is a parent comment, also delete all child comments
                if (comment.ParentCommentId == null)
                {
                    await _repository.DeleteChildCommentsAsync(request.Id);
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