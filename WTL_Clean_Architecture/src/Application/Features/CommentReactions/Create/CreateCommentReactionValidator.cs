using Application.Models;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.CommentReactions.Create
{
    public class CreateCommentReactionValidator : AbstractValidator<CreateCommentReactionDto>
    {
        public CreateCommentReactionValidator()
        {
            RuleFor(x => x.CommentId)
                .NotNull().WithMessage("Comment ID is required")
                .GreaterThan(0).WithMessage("Comment ID must be greater than 0");

            RuleFor(x => x.ReactionType)
                .NotNull().WithMessage("Reaction type is required")
                .IsInEnum().WithMessage("Invalid reaction type");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters")
                .When(x => x.Reason != null);

            // Require Reason when ReactionType is Report
            RuleFor(x => x.Reason)
                .NotNull().WithMessage("Reason is required when reporting a comment")
                .NotEmpty().WithMessage("Reason cannot be empty when reporting a comment")
                .When(x => x.ReactionType == CommentReactionType.Report);
        }
    }
} 