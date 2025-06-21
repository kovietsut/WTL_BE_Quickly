using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollectionPermissions.Create
{
    public class CreateFeaturedCollectionPermissionCommand : IRequest<IActionResult>
    {
        public List<string> UserIds { get; set; } = new();

        public required string FeaturedCollectionId { get; set; }

        public CollectionPermissionType PermissionType { get; set; }
    }

    public class CreateFeaturedCollectionPermissionCommandHandler(IFeaturedCollectionPermissionRepository repository,
        IFeaturedCollectionRepository featuredCollectionRepository,
        IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateFeaturedCollectionPermissionCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateFeaturedCollectionPermissionCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createCollectionPermissionDto = new CreateFeaturedCollectionPermissionDto
                {
                    UserIds = query.UserIds,
                    FeaturedCollectionId = query.FeaturedCollectionId,
                    PermissionType = query.PermissionType,
                };
                var validator = new CreateFeaturedCollectionPermissionValidator();
                var check = await validator.ValidateAsync(createCollectionPermissionDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var collection = await featuredCollectionRepository.GetFeaturedCollectionById(query.FeaturedCollectionId);
                if (collection == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection not found");
                }
                var collectionPermission = await repository.CreateListFeaturedCollectionPermissionAsync(createCollectionPermissionDto);
                return JsonUtil.Success(collectionPermission);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
