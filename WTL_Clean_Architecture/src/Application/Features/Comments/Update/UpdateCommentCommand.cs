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
        private readonly ErrorCode _errorCodes;

        public UpdateCommentCommandHandler(
            ICommentRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
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

                var comment = await _repository.UpdateCommentAsync(request.Id, updateCommentDto);
                return JsonUtil.Success(new { Id = comment.Id });
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