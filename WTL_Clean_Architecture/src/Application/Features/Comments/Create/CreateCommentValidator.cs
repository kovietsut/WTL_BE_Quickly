using Application.Models;
using FluentValidation;

namespace Application.Features.Comments.Create
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("UserId is required")
                .NotEmpty().WithMessage("UserId is required");

            RuleFor(x => x.Content)
                .NotNull().WithMessage("Content is required")
                .NotEmpty().WithMessage("Content cannot be empty")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");

            RuleFor(x => x.MangaId)
                .NotEmpty().WithMessage("MangaId is required")
                .When(x => x.MangaId != null);

            RuleFor(x => x.ChapterId)
                .NotEmpty().WithMessage("ChapterId is required")
                .When(x => x.ChapterId != null);

            RuleFor(x => x.ParentCommentId)
                .NotEmpty().WithMessage("ParentCommentId is required")
                .When(x => x.ParentCommentId != null);
        }
    }
} 