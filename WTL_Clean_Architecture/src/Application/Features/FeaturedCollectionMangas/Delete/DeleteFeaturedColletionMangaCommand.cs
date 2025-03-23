using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollectionMangas.Delete
{
    public class DeleteFeaturedColletionMangaCommand(long collectionId, long mangaId) : IRequest<IActionResult>
    {
        public long CollectionId { get; private set; } = collectionId;
        public long MangaId { get; private set; } = mangaId;
    }

    public class DeleteFeaturedColletionMangaCommandHandler : IRequestHandler<DeleteFeaturedColletionMangaCommand, IActionResult>
    {
        private readonly IFeaturedCollectionMangaRepository _repository;
        private readonly IFeaturedCollectionRepository _featuredCollectionRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ErrorCode _errorCodes;

        public DeleteFeaturedColletionMangaCommandHandler(IFeaturedCollectionMangaRepository repository, IFeaturedCollectionRepository featuredCollectionRepository,
            IMangaRepository mangaRepository
            , IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _featuredCollectionRepository = featuredCollectionRepository;
            _mangaRepository = mangaRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteFeaturedColletionMangaCommand query, CancellationToken cancellationToken)
        {
            var collection = await _featuredCollectionRepository.GetFeaturedCollectionById(query.CollectionId);
            if (collection == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection not found");
            }

            var manga = await _mangaRepository.GetMangaById(query.MangaId);
            if (manga == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Manga not found");
            }

            var collectionManga = await _repository.DeleteFeaturedCollectionMangaAsync(query.CollectionId, query.MangaId);
            if (collectionManga == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "FeaturedCollectionManga does not exist");
            }
            return JsonUtil.Success(collectionManga.Id);
        }
    }
}
