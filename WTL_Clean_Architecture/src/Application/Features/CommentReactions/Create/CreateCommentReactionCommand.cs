using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.CommentReactions.Create
{
    public class CreateCommentReactionCommand : IRequest<IActionResult>
    {
        public required long CommentId { get; set; }
        public required CommentReactionType ReactionType { get; set; }
        public string? Reason { get; set; }
    }

    public class CreateCommentReactionCommandHandler : IRequestHandler<CreateCommentReactionCommand, IActionResult>
    {
        private readonly ICommentReactionRepository _repository;
        private readonly ICommentRepository _commentRepository;
        private readonly IAuthenticationRepository _authRepository;
        private readonly ErrorCode _errorCodes;

        public CreateCommentReactionCommandHandler(
            ICommentReactionRepository repository,
            ICommentRepository commentRepository,
            IAuthenticationRepository authRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _commentRepository = commentRepository;
            _authRepository = authRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(CreateCommentReactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createCommentReactionDto = new CreateCommentReactionDto
                {
                    CommentId = request.CommentId,
                    ReactionType = request.ReactionType,
                    Reason = request.Reason
                };
                // Validate the command
                var validator = new CreateCommentReactionValidator();
                var validationResult = await validator.ValidateAsync(createCommentReactionDto, cancellationToken);
                
                if (!validationResult.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, "ValidationError", validationResult.Errors);
                }

                // Check if comment exists
                var comment = await _commentRepository.GetByIdAsync(request.CommentId);
                if (comment == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }

                // Get current user ID
                var currentUserId = _authRepository.GetUserId();
                 
                // Check if user already reacted to this comment
                var existingReaction = await _repository.GetByCommentAndUserAsync(request.CommentId, currentUserId);
                if (existingReaction != null)
                {
                    // If reaction type (like/dislike) is the same, delete the reaction (toggle off)
                    if (existingReaction.ReactionType != CommentReactionType.Report && existingReaction.ReactionType == request.ReactionType)
                    {
                        await _repository.DeleteAsync(existingReaction.Id);
                        return JsonUtil.Success(new { message = "Reaction removed" });
                    }
                    // If the current reaction type is like, user press dislike => update type to dislike (or the other way around)
                    else if (existingReaction.ReactionType != CommentReactionType.Report && existingReaction.ReactionType != request.ReactionType)
                    {
                        await _repository.UpdateAsync(existingReaction.Id, request.ReactionType, null);
                        return JsonUtil.Success(new { message = "Reaction updated" });
                    }
                    else if (existingReaction.ReactionType == CommentReactionType.Report)
                    {
                        await _repository.CreateAsync(request.CommentId, request.ReactionType, request.Reason);
                        return JsonUtil.Success(new { message = "Comment report created" });
                    } else
                    {
                        return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, "Invalid comment reaction");
                    }
                }

                // Create new reaction
                var reaction = await _repository.CreateAsync(request.CommentId, request.ReactionType, request.Reason);
                return JsonUtil.Success(new { reaction });
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
} 