using Application.Helpers;
using Application.Models;
using FluentValidation;

namespace Application.Features.FeaturedCollectionMangas.Create
{
    public class CreateFeaturedCollectionMangaValidator : AbstractValidator<CreateFeaturedCollectionMangaDto>
    {
        public CreateFeaturedCollectionMangaValidator()
        {
            RuleFor(x => x.MangaId).Must((mangaId) => CheckValidationHelper.IsNullOrDefault(mangaId))
                .WithMessage("MangaId cannot be empty");
            RuleFor(x => x.FeaturedCollectionId).Must((featuredCollectionId) => CheckValidationHelper.IsNullOrDefault(featuredCollectionId))
                .WithMessage("FeaturedCollectionId cannot be empty");
        }
    }
}
