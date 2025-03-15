using Application.Models;
using FluentValidation;

namespace Application.Features.FeaturedCollections.Create
{
    public class CreateFeaturedCollectionValidator : AbstractValidator<CreateFeaturedCollectionDto>
    {
        public CreateFeaturedCollectionValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name not empty");
        }
    }
}
