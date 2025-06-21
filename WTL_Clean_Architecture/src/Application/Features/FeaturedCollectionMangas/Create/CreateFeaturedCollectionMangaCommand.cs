using Application.Features.FeaturedCollectionMangas.Create;
using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Create
{
    public class CreateFeaturedCollectionMangaCommand : IRequest<IActionResult>
    {
        public required string MangaId { get; set; }
        public required string FeaturedCollectionId { get; set; }
    }

    public class CreateFeaturedCollectionMangaCommandHandler(IFeaturedCollectionMangaRepository repository, IMangaRepository mangaRepository,
        IFeaturedCollectionRepository featuredCollectionRepository,
        IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateFeaturedCollectionMangaCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateFeaturedCollectionMangaCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createCollectionMangaDto = new CreateFeaturedCollectionMangaDto
                {
                    FeaturedCollectionId = query.FeaturedCollectionId,
                    MangaId = query.MangaId,
                };
                var validator = new CreateFeaturedCollectionMangaValidator();
                var check = await validator.ValidateAsync(createCollectionMangaDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var collection = await featuredCollectionRepository.GetFeaturedCollectionById(query.FeaturedCollectionId);
                if (collection == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Collection not found");
                }

                var manga = await mangaRepository.GetMangaById(query.MangaId);
                if(manga == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Manga not found");
                }

                var collectionManga = await repository.GetFeaturedCollectionMangaById(query.FeaturedCollectionId, query.MangaId);
                if (collectionManga != null)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.BadRequest, "This manga has already existed in collection");
                }
                collectionManga = await repository.CreateFeaturedCollectionMangaAsync(createCollectionMangaDto);
                return JsonUtil.Success(collectionManga.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
