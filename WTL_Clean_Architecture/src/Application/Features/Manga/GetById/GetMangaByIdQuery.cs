using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Mappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.GetById
{
    public class GetMangaByIdQuery(string id) : IRequest<IActionResult>
    {
        public string Id { get; private set; } = id;
    }

    public class GetMangaByIdQueryHandler : IRequestHandler<GetMangaByIdQuery, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetMangaByIdQueryHandler(IMangaRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetMangaByIdQuery query, CancellationToken cancellationToken)
        {
            var manga = await _repository.GetMangaById(query.Id);
            if (manga == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Manga does not exist");
            }
            var result = new
            {
                manga.Id,
                manga.IsDeleted,
                manga.Title,
                manga.PublishedDate,
                Format = MangaMapper.ToDtoFormat(manga.Format),
                Region = MangaMapper.ToDtoRegion(manga.Region),
                ReleaseStatus = MangaMapper.ToDtoReleaseStatus(manga.ReleaseStatus),
                manga.Preface,
                manga.CoverImage,
                manga.CreatedBy,
                SubAuthorId = manga.SubAuthor,
                PublishorId = manga.Publishor,
                ArtistId = manga.Artist,
                TranslatorId = manga.Translator,
                Genres = manga.MangaGenres.Where(mg => mg.IsDeleted != true && mg.Genre.IsDeleted != true)
                    .Select(mg => new { mg.Genre.Id, mg.Genre.Name }),
                Author = manga.SubAuthorNavigation != null ? new { manga.SubAuthorNavigation.Id, manga.SubAuthorNavigation.FullName } : null,
                Artist = manga.ArtistNavigation != null ? new { manga.ArtistNavigation.Id, manga.ArtistNavigation.FullName } : null,
                Translator = manga.TranslatorNavigation != null ? new { manga.TranslatorNavigation.Id, manga.TranslatorNavigation.FullName } : null,
                Publisher = manga.PublishorNavigation != null ? new { manga.PublishorNavigation.Id, manga.PublishorNavigation.FullName } : null
            };
            return JsonUtil.Success(result);
        }
    }
}
