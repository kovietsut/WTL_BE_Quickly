using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.GetById
{
    public class GetFeaturedCollectionByIdQuery(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class GetFeaturedCollectionByIdQueryHandler : IRequestHandler<GetFeaturedCollectionByIdQuery, IActionResult>
    {
        private readonly IFeaturedCollectionRepository _repository;
        private readonly ErrorCode _errorCodes;
        private readonly IUserRepository _userRepository;
        private readonly IFeaturedCollectionPermissionRepository _permissionRepository;
        private readonly IAuthenticationRepository _authenticationRepository;

        public GetFeaturedCollectionByIdQueryHandler(
            IFeaturedCollectionRepository repository, 
            IOptions<ErrorCode> errorCodes,
            IUserRepository userRepository,
            IFeaturedCollectionPermissionRepository permissionRepository,
            IAuthenticationRepository authenticationRepository)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
            _authenticationRepository = authenticationRepository;
        }

        public async Task<IActionResult> Handle(GetFeaturedCollectionByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                // Get current user ID
                var currentUserId = _authenticationRepository.GetUserId();

                // Check if collection exists
                var collection = await _repository.GetFeaturedCollectionById(query.Id);
                if (collection == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection does not exist");
                }

                // Check if user is the creator or has permission
                bool hasAccess = collection.CreatedBy == currentUserId;
                if (!hasAccess)
                {
                    var permission = await _permissionRepository.GetFeaturedCollectionPermissionById(collection.Id, currentUserId);
                    hasAccess = permission != null && !permission.IsDeleted && 
                               (permission.PermissionType == CollectionPermissionType.Read || 
                                permission.PermissionType == CollectionPermissionType.Write);
                }

                if (!hasAccess)
                {
                    return JsonUtil.Error(StatusCodes.Status403Forbidden, _errorCodes?.Status403?.Forbidden, "User does not have permission to view this collection");
                }

                var result = new
                {
                    collection.Id,
                    collection.IsDeleted,
                    collection.Name,
                    collection.CreatedAt,
                    collection.UpdatedAt,
                    //mangas
                    //owner
                    //number of novel, webtoon, saves
                };
                return JsonUtil.Success(result);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
