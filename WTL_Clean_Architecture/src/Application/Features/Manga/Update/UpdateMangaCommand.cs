using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.Update
{
    public class UpdateMangaCommand : IRequest<IActionResult>
    {
        public required long Id { get; set; }
        public string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int? Format { get; set; }

        public int? Season { get; set; }

        public int? Region { get; set; }

        public int? ReleaseStatus { get; set; }

        public string? Preface { get; set; }

        public bool? HasAdult { get; set; }

        public string? CoverImage { get; set; }

        public long? SubAuthor { get; set; }

        public long? Publishor { get; set; }

        public long? Artist { get; set; }

        public long? Translator { get; set; }
    }

    public class UpdateMangaCommmandHandler(IMangaRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<UpdateMangaCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(UpdateMangaCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var updateMangaDto = new UpdateMangaDto
                {
                    Title = query.Title,
                    PublishedDate = query.PublishedDate,
                    Format = query.Format,
                    Season = query.Season,
                    Region = query.Region,
                    ReleaseStatus = query.ReleaseStatus,
                    Preface = query.Preface,
                    HasAdult = query.HasAdult,
                    SubAuthor = query.SubAuthor,
                    Publishor = query.Publishor,
                    Artist = query.Artist,
                    Translator = query.Translator
                };
                var validator = new UpdateMangaValidator();
                var check = await validator.ValidateAsync(updateMangaDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var manga = await repository.UpdateMangaAsync(query.Id, updateMangaDto);
                return JsonUtil.Success(manga.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
