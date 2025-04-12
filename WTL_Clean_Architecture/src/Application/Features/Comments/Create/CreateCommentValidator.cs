using Application.Models;
using FluentValidation;

namespace Application.Features.Comments.Commands.Create
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.Content)
                .NotNull().WithMessage("Content is required")
                .NotEmpty().WithMessage("Content cannot be empty")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");

            RuleFor(x => x.MangaId)
                .GreaterThan(0).WithMessage("MangaId must be greater than 0")
                .When(x => x.MangaId.HasValue);

            RuleFor(x => x.ChapterId)
                .GreaterThan(0).WithMessage("ChapterId must be greater than 0")
                .When(x => x.ChapterId.HasValue);

            RuleFor(x => x.ParentCommentId)
                .GreaterThan(0).WithMessage("ParentCommentId must be greater than 0")
                .When(x => x.ParentCommentId.HasValue);
        }
    }
} 