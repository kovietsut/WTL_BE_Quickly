using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Update
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreDto>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
        }
    }
}
