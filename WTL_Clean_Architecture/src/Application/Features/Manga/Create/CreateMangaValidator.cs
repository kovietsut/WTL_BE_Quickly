using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Manga.Create
{
    public class CreateMangaValidator : AbstractValidator<CreateMangaDto>
    {
        public CreateMangaValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title is required")
                .NotEmpty().WithMessage("Title not empty");
        }
    }
}
