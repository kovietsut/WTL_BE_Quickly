using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Comments.Update
{
    public class UpdateCommentCommand : IRequest<IActionResult>
    {
        public required long Id { get; set; }
        public string Content { get; set; }
        public bool IsSpoiler { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, IActionResult>
    {
        private readonly ICommentRepository _repository;
        private readonly IAuthenticationRepository _authRepository;
        private readonly ErrorCode _errorCodes;

        public UpdateCommentCommandHandler(
            ICommentRepository repository,
            IAuthenticationRepository authRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _authRepository = authRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the comment to check ownership
                var comment = await _repository.GetByIdAsync(request.Id);
                if (comment == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }

                // Get the current user ID from the authentication repository
                var currentUserId = _authRepository.GetUserId();

                // Check if the current user is the creator of the comment
                if (comment.UserId != currentUserId)
                {
                    return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden, "You do not have permission to update this comment");
                }

                var updateCommentDto = new UpdateCommentDto
                {
                    Content = request.Content,
                    IsSpoiler = request.IsSpoiler
                };

                var validator = new UpdateCommentValidator();
                var validationResult = await validator.ValidateAsync(updateCommentDto, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, "ValidationError", validationResult.Errors);
                }

                var updatedComment = await _repository.UpdateCommentAsync(request.Id, updateCommentDto);
                return JsonUtil.Success(new { Id = updatedComment.Id });
            }
            catch (ArgumentNullException)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
} 