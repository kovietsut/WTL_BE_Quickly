using Application.Features.Chapter.Create;
using Application.Features.Chapter.Delete;
using Application.Features.Chapter.GetById;
using Application.Features.Chapter.GetList;
using Application.Features.Chapter.Update;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChapterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChapterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{chapterId}")]
        public async Task<IActionResult> Get(string chapterId)
        {
            var query = new GetChapterByIdQuery(chapterId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var query = new GetListChapterQuery(pageNumber, pageSize, searchText);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChapterAsync([FromBody] CreateChapterDto model)
        {
            var query = new CreateChapterCommand()
            {
                MangaId = model.MangaId,
                Name = model.Name,
                NovelContent = model.NovelContent,
                HasDraft = model.HasDraft,
                ThumbnailImage = model.ThumbnailImage,
                PublishedDate = model.PublishedDate,
                HasComment = model.HasComment,
                StatusChapter = model.StatusChapter,
                ImageList = model.ImageList
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{chapterId}")]
        public async Task<IActionResult> UpdateChapterAsync(string chapterId, [FromBody] UpdateChapterDto model)
        {
            var query = new UpdateChapterCommand()
            {
                Id = chapterId,
                Name = model.Name,
                NovelContent = model.Name,
                HasDraft = model.HasDraft,
                ThumbnailImage = model.ThumbnailImage,
                PublishedDate = model.PublishedDate,
                HasComment = model.HasComment,
                StatusChapter = model.StatusChapter,
                ImageList = model.ImageList
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete("{chapterId}")]
        public async Task<IActionResult> DeleteChapterAsync(string chapterId)
        {
            var query = new DeleteChapterCommand(chapterId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
