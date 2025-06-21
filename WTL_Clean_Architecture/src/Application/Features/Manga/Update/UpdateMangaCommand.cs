using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.Update
{
    public class UpdateMangaCommand : IRequest<IActionResult>
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public MangaFormat? Format { get; set; }
        public MangaRegion? Region { get; set; }
        public MangaReleaseStatus? ReleaseStatus { get; set; }
        public string? Preface { get; set; }
        public bool? HasAdult { get; set; }
        public string? SubAuthor { get; set; }
        public string? Publishor { get; set; }
        public string? Artist { get; set; }
        public string? Translator { get; set; }
        public List<string>? GenreIds { get; set; }
    }

    public class UpdateMangaCommmandHandler : IRequestHandler<UpdateMangaCommand, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly IMangaGenreRepository _mangaGenreRepository;
        private readonly IUserRepository _userRepository;
        private readonly ErrorCode _errorCodes;

        public UpdateMangaCommmandHandler(
            IMangaRepository repository, 
            IMangaGenreRepository mangaGenreRepository,
            IUserRepository userRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _mangaGenreRepository = mangaGenreRepository;
            _userRepository = userRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateMangaCommand query, CancellationToken cancellationToken)
        {
            try
            {
                if (!string.IsNullOrEmpty(query.SubAuthor))
                {
                    var subAuthor = await _userRepository.GetByIdAsync(query.SubAuthor);
                    if (subAuthor == null)
                    {
                        return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "SubAuthor user does not exist");
                    }
                }

                if (!string.IsNullOrEmpty(query.Publishor))
                {
                    var publishor = await _userRepository.GetByIdAsync(query.Publishor);
                    if (publishor == null)
                    {
                        return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "Publishor user does not exist");
                    }
                }

                if (!string.IsNullOrEmpty(query.Artist))
                {
                    var artist = await _userRepository.GetByIdAsync(query.Artist);
                    if (artist == null)
                    {
                        return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "Artist user does not exist");
                    }
                }

                if (!string.IsNullOrEmpty(query.Translator))
                {
                    var translator = await _userRepository.GetByIdAsync(query.Translator);
                    if (translator == null)
                    {
                        return JsonUtil.Error(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", "Translator user does not exist");
                    }
                }

                var updateMangaDto = new UpdateMangaDto
                {
                    Title = query.Title,
                    PublishedDate = query.PublishedDate,
                    Format = (MangaFormat?)query.Format,
                    Region = (MangaRegion?)query.Region,
                    ReleaseStatus = (MangaReleaseStatus?)query.ReleaseStatus,
                    Preface = query.Preface,
                    HasAdult = query.HasAdult,
                    SubAuthor = query.SubAuthor,
                    Publishor = query.Publishor,
                    Artist = query.Artist,
                    Translator = query.Translator,
                    GenreIds = query.GenreIds
                };
                var validator = new UpdateMangaValidator();
                var check = await validator.ValidateAsync(updateMangaDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var manga = await _repository.UpdateMangaAsync(query.Id, updateMangaDto);

                if (query.GenreIds != null && query.GenreIds.Any())
                {
                    await _mangaGenreRepository.DeleteMangaGenresAsync(query.Id);
                    await _mangaGenreRepository.CreateMangaGenresAsync(query.Id, query.GenreIds);
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
