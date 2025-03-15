using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
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
        private readonly ErrorCode _errorCodes;

        public DeleteFeaturedCollectionCommandHandler(IFeaturedCollectionRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteFeaturedCollectionCommand query, CancellationToken cancellationToken)
        {
            var collection = await _repository.DeleteFeaturedCollectionAsync(query.Id);
            if (collection == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Collection does not exist");
            }
            return JsonUtil.Success(collection.Id);
        }
    }
}
