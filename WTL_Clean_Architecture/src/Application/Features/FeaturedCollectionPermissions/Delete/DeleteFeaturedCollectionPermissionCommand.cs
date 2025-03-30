using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollectionPermissions.Delete
{
    public class DeleteFeaturedCollectionPermissionCommand(long collectionId, List<long> userIds) : IRequest<IActionResult>
    {
        public long CollectionId { get; private set; } = collectionId;
        public List<long> userIds { get; private set; } = userIds;
    }

    public class DeleteFeaturedCollectionPermissionCommandHandler : IRequestHandler<DeleteFeaturedCollectionPermissionCommand, IActionResult>
    {
        private readonly IFeaturedCollectionPermissionRepository _repository;
        private readonly IFeaturedCollectionRepository _featuredCollectionRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ErrorCode _errorCodes;

        public DeleteFeaturedCollectionPermissionCommandHandler(IFeaturedCollectionPermissionRepository repository, IFeaturedCollectionRepository featuredCollectionRepository,
            IMangaRepository mangaRepository
            , IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _featuredCollectionRepository = featuredCollectionRepository;
            _mangaRepository = mangaRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteFeaturedCollectionPermissionCommand query, CancellationToken cancellationToken)
        {
            var collection = await _featuredCollectionRepository.GetFeaturedCollectionById(query.CollectionId);
            if (collection == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection not found");
            }

            var result = await _repository.DeleteListFeaturedCollectionPermissionAsync(query.CollectionId, query.userIds);
            if (result == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "FeaturedCollectionPermission does not exist");
            }
            return JsonUtil.Success(result);
        }
    }
}
