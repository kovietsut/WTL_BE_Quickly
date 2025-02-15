using Application.Helpers;
using Application.Models;
using FluentValidation;

namespace Application.Features.Genres.Create
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreDto>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
        }
    }
}
