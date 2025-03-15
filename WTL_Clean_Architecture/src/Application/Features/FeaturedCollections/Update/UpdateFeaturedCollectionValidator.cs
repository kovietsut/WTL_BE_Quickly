using Application.Models;
using FluentValidation;

namespace Application.Features.FeaturedCollections.Update
{
    public class UpdateFeaturedCollectionValidator : AbstractValidator<UpdateFeaturedCollectionDto>
    {
        public UpdateFeaturedCollectionValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
        }
    }
}
