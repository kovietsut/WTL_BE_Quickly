using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Update
{
    public class UpdateFeaturedCollectionCommand : IRequest<IActionResult>
    {
        public required long Id { get; set; }
        public string Name { get; set; }
        public string? CoverImage { get; set; }
        public bool? IsPublish { get; set; }
    }
    public class UpdateFeaturedCollectionCommandHandler : IRequestHandler<UpdateFeaturedCollectionCommand, IActionResult>
    {
        private readonly IFeaturedCollectionRepository _repository;
        private readonly IFeaturedCollectionPermissionRepository _permissionRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ErrorCode _errorCodes;

        public UpdateFeaturedCollectionCommandHandler(
            IFeaturedCollectionRepository repository, 
            IFeaturedCollectionPermissionRepository permissionRepository,
            IAuthenticationRepository authenticationRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _permissionRepository = permissionRepository;
            _authenticationRepository = authenticationRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateFeaturedCollectionCommand query, CancellationToken cancellationToken)
        {
            try
            {
                // Get current user ID
                var currentUserId = _authenticationRepository.GetUserId();

                // Check if collection exists
                var currentCollection = await _repository.GetByIdAsync(query.Id);
                if (currentCollection == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Collection does not exist");
                }

                // Check if user has permission to update this collection
                var permission = await _permissionRepository.GetFeaturedCollectionPermissionById(query.Id, currentUserId);
                if (permission == null || permission.PermissionType != CollectionPermissionType.Write)
                {
                    return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden ?? "Forbidden", "User does not have permission to update this collection");
                }

                var updateCollectionDto = new UpdateFeaturedCollectionDto
                {
                    Name = query.Name,
                    CoverImage = query.CoverImage,
                    IsPublish = query.IsPublish
                };
                var validator = new UpdateFeaturedCollectionValidator();
                var check = await validator.ValidateAsync(updateCollectionDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var chapter = await _repository.UpdateFeaturedCollectionAsync(query.Id, updateCollectionDto);
                return JsonUtil.Success(chapter.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
