using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.Create
{
    public class CreateMangaCommand : IRequest<IActionResult>
    {
        public string Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public MangaFormat? Format { get; set; }
        public MangaRegion? Region { get; set; }
        public MangaReleaseStatus? ReleaseStatus { get; set; }
        public string? Preface { get; set; }
        public bool? HasAdult { get; set; }
        public long? CreatedBy { get; set; }
        public long? SubAuthor { get; set; }
        public long? Publishor { get; set; }
        public long? Artist { get; set; }
        public long? Translator { get; set; }
        public List<long>? GenreIds { get; set; }
    }

    public class CreateMangaCommmandHandler : IRequestHandler<CreateMangaCommand, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly IMangaGenreRepository _mangaGenreRepository;
        private readonly ErrorCode _errorCodes;

        public CreateMangaCommmandHandler(
            IMangaRepository repository,
            IMangaGenreRepository mangaGenreRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _mangaGenreRepository = mangaGenreRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(CreateMangaCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createMangaDto = new CreateMangaDto
                {
                    Title = query.Title,
                    PublishedDate = query.PublishedDate,
                    Format = (MangaFormat?)query.Format,
                    Region = (MangaRegion?)query.Region,
                    ReleaseStatus = (MangaReleaseStatus?)query.ReleaseStatus,
                    Preface = query.Preface,
                    HasAdult = query.HasAdult,
                    CreatedBy = query.CreatedBy,
                    SubAuthor = query.SubAuthor,
                    Publishor = query.Publishor,
                    Artist = query.Artist,
                    Translator = query.Translator,
                    GenreIds = query.GenreIds
                };
                var validator = new CreateMangaValidator();
                var check = await validator.ValidateAsync(createMangaDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var manga = await _repository.CreateMangaAsync(createMangaDto);
                
                if (query.GenreIds != null && query.GenreIds.Any())
                {
                    await _mangaGenreRepository.CreateMangaGenresAsync(manga.Id, query.GenreIds);
                }

                return JsonUtil.Success(manga.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
