using Application.Models;
using FluentValidation;

namespace Application.Features.Manga.UploadCover
{
    public class UploadMangaCoverValidator : AbstractValidator<UploadMangaCoverDto>
    {
        public UploadMangaCoverValidator()
        {
            RuleFor(x => x.MangaId)
                .NotEmpty()
                .WithMessage("MangaId is required");

            RuleFor(x => x.CoverImageFile)
                .NotNull()
                .WithMessage("Cover image file is required");

            RuleFor(x => x.CoverImageFile.Length)
                .GreaterThan(0)
                .WithMessage("Cover image file cannot be empty");

            // RuleFor(x => x.CoverImageFile.ContentType)
            //     .Must(contentType => contentType.StartsWith("image/"))
            //     .WithMessage("File must be an image");
        }
    }
} 