using Application.Models;
using FluentValidation;

namespace Application.Features.Comments.Update
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.Content)
                // .NotNull().WithMessage("Content is required")
                // .NotEmpty().WithMessage("Content cannot be empty")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");
        }
    }
} 