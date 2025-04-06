using Application.Models;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.MangaInteractions.Create
{
    public class CreateMangaInteractionValidator : AbstractValidator<CreateMangaInteractionDto>
    {
        public CreateMangaInteractionValidator()
        {
            RuleFor(x => x.MangaId)
                .NotEmpty()
                .When(x => x.ChapterId == null)
                .WithMessage("Either MangaId or ChapterId must be provided");

            RuleFor(x => x.ChapterId)
                .NotEmpty()
                .When(x => x.MangaId == null)
                .WithMessage("Either MangaId or ChapterId must be provided");

            RuleFor(x => x.InteractionType)
                .NotEmpty()
                .WithMessage("InteractionType is required")
                .IsInEnum()
                .WithMessage("Invalid InteractionType value");
        }
    }
}
