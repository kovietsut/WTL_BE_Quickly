using Application.Models;
using FluentValidation;

namespace Application.Features.Manga.UploadCover
{
    public class UploadMangaCoverValidator : AbstractValidator<UploadMangaCoverDto>
    {
        public UploadMangaCoverValidator()
        {
            RuleFor(x => x.MangaId)
                .GreaterThan(0)
                .WithMessage("MangaId must be greater than 0");

            RuleFor(x => x.CoverImageFile)
                .NotNull()
                .WithMessage("Cover image file is required");

            RuleFor(x => x.CoverImageFile.Length)
                .GreaterThan(0)
                .WithMessage("Cover image file cannot be empty");

            RuleFor(x => x.CoverImageFile.ContentType)
                .Must(x => x != null && (x.StartsWith("image/") || x == "application/octet-stream"))
                .WithMessage("File must be an image");
        }
    }
} 