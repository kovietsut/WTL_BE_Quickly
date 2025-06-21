using Application.Features.Comments.Create;
using Application.Interfaces;
using Application.Models;
using Application.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<IActionResult>
    {
        public string? MangaId { get; set; }
        public required string UserId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public string? ChapterId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, IActionResult>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var createCommentDto = new CreateCommentDto
            {
                MangaId = request.MangaId,
                UserId = request.UserId,
                ParentCommentId = request.ParentCommentId,
                Content = request.Content,
                IsSpoiler = request.IsSpoiler,
                ChapterId = request.ChapterId
            };
                
            var validator = new CreateCommentValidator();
            var validationResult = await validator.ValidateAsync(createCommentDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return JsonUtil.Errors(StatusCodes.Status400BadRequest, "ValidationError", validationResult.Errors);
            }

            var comment = await _commentRepository.CreateCommentAsync(createCommentDto);
            
            return JsonUtil.Success(new { Id = comment.Id });
        }
    }
} 