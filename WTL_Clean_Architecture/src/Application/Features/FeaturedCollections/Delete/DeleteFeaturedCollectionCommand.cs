using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Delete
{
    public class DeleteFeaturedCollectionCommand(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class DeleteFeaturedCollectionCommandHandler : IRequestHandler<DeleteFeaturedCollectionCommand, IActionResult>
    {
        private readonly IFeaturedCollectionRepository _repository;
        private readonly IFeaturedCollectionPermissionRepository _permissionRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ErrorCode _errorCodes;

        public DeleteFeaturedCollectionCommandHandler(
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

        public async Task<IActionResult> Handle(DeleteFeaturedCollectionCommand query, CancellationToken cancellationToken)
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

                // Check if user has permission to delete this collection
                var permission = await _permissionRepository.GetFeaturedCollectionPermissionById(query.Id, currentUserId);
                if (permission == null || permission.PermissionType != CollectionPermissionType.Write)
                {
                    return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden ?? "Forbidden", "User does not have permission to delete this collection");
                }

                var collection = await _repository.DeleteFeaturedCollectionAsync(query.Id);
                return JsonUtil.Success(collection.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
