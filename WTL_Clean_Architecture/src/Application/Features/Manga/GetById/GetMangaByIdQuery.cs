using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.GetById
{
    public class GetMangaByIdQuery(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
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
                manga.Format,
                manga.Season,
                manga.Preface,
                manga.CoverImage,
                manga.CreatedBy,
                manga.SubAuthor,
                manga.Publishor,
                manga.Artist,
                manga.Translator
                //list genres
                //list chapters
                //list comments
            };
            return JsonUtil.Success(result);
        }
    }

}
