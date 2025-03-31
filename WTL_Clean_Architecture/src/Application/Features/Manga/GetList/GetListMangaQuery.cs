using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Mappers;
using Domain.SpecificationModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.GetList
{
    public class GetListMangaQuery : IRequest<IActionResult>
    {
        public MangaFilterDto Filter { get; set; }
    }

    public class GetListMangaQueryHandler : IRequestHandler<GetListMangaQuery, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly ErrorCode _errorCodes;
        private readonly ISasTokenGenerator _sasTokenGenerator;

        public GetListMangaQueryHandler(IMangaRepository repository, IOptions<ErrorCode> errorCodes, ISasTokenGenerator sasTokenGenerator)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
            _sasTokenGenerator = sasTokenGenerator ?? throw new ArgumentNullException(nameof(sasTokenGenerator));
        }

        public async Task<IActionResult> Handle(GetListMangaQuery query, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository.GetList(query.Filter);
            var listData = items.Select(x => {
                var latestChapter = x.Chapters.OrderByDescending(c => c.Id).FirstOrDefault();
                return new
                {
                    x.Id,
                    x.IsDeleted,
                    x.Title,
                    CoverImage = _sasTokenGenerator.GenerateCoverImageUriWithSas(x.CoverImage),
                    Format = MangaMapper.ToDtoFormat(x.Format),
                    Region = MangaMapper.ToDtoRegion(x.Region),
                    ReleaseStatus = MangaMapper.ToDtoReleaseStatus(x.ReleaseStatus),
                    x.PublishedDate,
                    x.Preface,
                    x.HasAdult,
                    x.CreatedAt,
                    x.UpdatedAt,
                    Genres = x.MangaGenres.Where(mg => mg.IsDeleted != true && mg.Genre.IsDeleted != true)
                        .Select(mg => new { mg.Genre.Id, mg.Genre.Name }),
                    Author = x.SubAuthorNavigation != null ? new { x.SubAuthorNavigation.Id, x.SubAuthorNavigation.FullName } : null,
                    Artist = x.ArtistNavigation != null ? new { x.ArtistNavigation.Id, x.ArtistNavigation.FullName } : null,
                    Translator = x.TranslatorNavigation != null ? new { x.TranslatorNavigation.Id, x.TranslatorNavigation.FullName } : null,
                    Publisher = x.PublishorNavigation != null ? new { x.PublishorNavigation.Id, x.PublishorNavigation.FullName } : null,
                    LatestChapter = latestChapter != null ? new
                    {
                        latestChapter.Id,
                        latestChapter.ChapterNumber,
                        latestChapter.Name,
                        latestChapter.PublishedDate,
                        latestChapter.CreatedAt
                    } : null
                };
            });

            if (listData != null)
            {
                return JsonUtil.Success(listData, dataCount: totalCount);
            }
            return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Empty List Data");
        }
    }
}
