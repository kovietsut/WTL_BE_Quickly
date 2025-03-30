using Application.Helpers;
using Application.Models;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.FeaturedCollectionPermissions.Create
{
    public class CreateFeaturedCollectionPermissionValidator : AbstractValidator<CreateFeaturedCollectionPermissionDto>
    {
        public CreateFeaturedCollectionPermissionValidator()
        {
            RuleFor(x => x.PermissionType)
                .IsInEnum()
                .WithMessage("Invalid permission type");
            RuleFor(x => x.FeaturedCollectionId).Must((featuredCollectionId) => CheckValidationHelper.IsNullOrDefault(featuredCollectionId))
                .WithMessage("FeaturedCollectionId cannot be empty");
            RuleFor(x => x.UserIds)
                .NotEmpty()
                .WithMessage("UserIds cannot be empty");
        }
    }
}
