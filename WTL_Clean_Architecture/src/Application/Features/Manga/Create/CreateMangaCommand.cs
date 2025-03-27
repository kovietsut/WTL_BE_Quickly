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
        public MangaSeason? Season { get; set; }
        public MangaRegion? Region { get; set; }
        public MangaReleaseStatus? ReleaseStatus { get; set; }
        public string? Preface { get; set; }
        public bool? HasAdult { get; set; }
        public string? CoverImage { get; set; }
        public long? CreatedBy { get; set; }
        public long? SubAuthor { get; set; }
        public long? Publishor { get; set; }
        public long? Artist { get; set; }
        public long? Translator { get; set; }
    }

    public class CreateMangaCommmandHandler(IMangaRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateMangaCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateMangaCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createMangaDto = new CreateMangaDto
                {
                    Title = query.Title,
                    PublishedDate = query.PublishedDate,
                    Format = query.Format,
                    Season = query.Season,
                    Region = query.Region,
                    ReleaseStatus = query.ReleaseStatus,
                    Preface = query.Preface,
                    HasAdult = query.HasAdult,
                    CoverImage = query.CoverImage,
                    CreatedBy = query.CreatedBy,
                    SubAuthor = query.SubAuthor,
                    Publishor = query.Publishor,
                    Artist = query.Artist,
                    Translator = query.Translator
                };
                var validator = new CreateMangaValidator(); 
                var check = await validator.ValidateAsync(createMangaDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                
                var user = await repository.CreateMangaAsync(createMangaDto);
                return JsonUtil.Success(user.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
