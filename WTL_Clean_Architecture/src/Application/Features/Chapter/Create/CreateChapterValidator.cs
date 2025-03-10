using Application.Models;
using FluentValidation;

namespace Application.Features.Chapter.Create
{
    public class CreateChapterValidator : AbstractValidator<CreateChapterDto>
    {
        public CreateChapterValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
            RuleFor(x => x.HasDraft).NotNull().WithMessage("HasDraft is required")
                .NotEmpty().WithMessage("HasDraft not empty");
            RuleFor(x => x.PublishedDate).NotNull().WithMessage("PublishedDate is required")
                .NotEmpty().WithMessage("PublishedDate not empty");
            RuleFor(x => x.StatusChapter).NotNull().WithMessage("StatusChapter is required")
                .NotEmpty().WithMessage("StatusChapter not empty");
        }
    }
}
