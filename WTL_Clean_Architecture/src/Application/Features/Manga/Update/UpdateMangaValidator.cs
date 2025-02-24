using Application.Models;
using FluentValidation;

namespace Application.Features.Manga.Update
{
    public class UpdateMangaValidator: AbstractValidator<UpdateMangaDto>
    {
        public UpdateMangaValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title is required")
                .NotEmpty().WithMessage("Title not empty");
        }
    }
}
