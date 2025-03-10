using Application.Models;
using FluentValidation;

namespace Application.Features.Chapter.Update
{
    public class UpdateChapterValidator : AbstractValidator<UpdateChapterDto>
    {
        public UpdateChapterValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
        }
    }
}
