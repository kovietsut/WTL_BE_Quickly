using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Chapter.Update
{
    public class UpdateChapterCommand : IRequest<IActionResult>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? NovelContent { get; set; }
        public bool? HasDraft { get; set; }
        public string? ThumbnailImage { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool? HasComment { get; set; }
        public int? StatusChapter { get; set; }
        public required List<ChapterImageDto> ImageList { get; set; }
    }
    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, IActionResult>
    {
        private readonly IChapterRepository _repository;
        private readonly ErrorCode _errorCodes;

        public UpdateChapterCommandHandler(IChapterRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateChapterCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var updateChapterDto = new UpdateChapterDto
                {
                    Name = query.Name,
                    NovelContent = query.Name,
                    HasDraft = query.HasDraft,
                    ThumbnailImage = query.ThumbnailImage,
                    PublishedDate = query.PublishedDate,
                    HasComment = query.HasComment,
                    StatusChapter = query.StatusChapter,
                    ImageList = query.ImageList
                };
                var validator = new UpdateChapterValidator();
                var check = await validator.ValidateAsync(updateChapterDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var currentChapter = await _repository.GetByIdAsync(query.Id);
                if (currentChapter == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Chapter does not exist");
                }
                var chapter = await _repository.UpdateChapterAsync(query.Id, updateChapterDto);
                return JsonUtil.Success(chapter.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
