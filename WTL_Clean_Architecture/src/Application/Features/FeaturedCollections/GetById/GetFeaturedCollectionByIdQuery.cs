using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
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

        public GetFeaturedCollectionByIdQueryHandler(IFeaturedCollectionRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetFeaturedCollectionByIdQuery query, CancellationToken cancellationToken)
        {
            var collection = await _repository.GetFeaturedCollectionById(query.Id);
            if (collection == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection does not exist");
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
    }
}
