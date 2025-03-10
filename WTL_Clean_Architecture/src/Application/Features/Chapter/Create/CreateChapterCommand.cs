using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Chapter.Create
{
    public class CreateChapterCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string? NovelContent { get; set; }
        public bool? HasDraft { get; set; }
        public string? ThumbnailImage { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool? HasComment { get; set; }
        public int? StatusChapter { get; set; }
        public List<ChapterImageDto> ImageList { get; set; }
    }

    public class CreateChapterCommmandHandler(IChapterRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateChapterCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateChapterCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createChapterDto = new CreateChapterDto
                {
                    Name = query.Name,
                    NovelContent = query.NovelContent,
                    HasDraft = query.HasDraft,
                    ThumbnailImage = query.ThumbnailImage,
                    PublishedDate = query.PublishedDate,
                    HasComment = query.HasComment,
                    StatusChapter = query.StatusChapter,
                    ImageList = query.ImageList
                };
                var validator = new CreateChapterValidator();
                var check = await validator.ValidateAsync(createChapterDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var chapter = await repository.CreateChapterAsync(createChapterDto);
                return JsonUtil.Success(chapter.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
