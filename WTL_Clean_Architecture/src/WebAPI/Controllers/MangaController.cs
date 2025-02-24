using Application.Features.Manga.Create;
using Application.Features.Manga.Delete;
using Application.Features.Manga.GetById;
using Application.Features.Manga.GetList;
using Application.Features.Manga.Update;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[EnableRateLimiting("fixed")]
    public class MangaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetMangaByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        [AllowAnonymous]
        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var query = new GetListMangaQuery(pageNumber, pageSize, searchText);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManga([FromBody] CreateMangaDto model)
        {
            var query = new CreateMangaCommand()
            {
                Title = model.Title,
                PublishedDate = model.PublishedDate,
                Format = model.Format,
                Season = model.Season,
                Region = model.Region,
                ReleaseStatus = model.ReleaseStatus,
                Preface = model.Preface,
                HasAdult = model.HasAdult,
                CreatedBy = model.CreatedBy,
                SubAuthor = model.SubAuthor,
                Publishor = model.Publishor,
                Artist = model.Artist,
                Translator = model.Translator
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{mangaId}")]
        public async Task<IActionResult> Update(int mangaId, [FromBody] UpdateMangaDto model)
        {
            var query = new UpdateMangaCommand()
            {
                Id = mangaId,
                Title = model.Title,
                PublishedDate = model.PublishedDate,
                Format = model.Format,
                Season = model.Season,
                Region = model.Region,
                ReleaseStatus = model.ReleaseStatus,
                Preface = model.Preface,
                HasAdult = model.HasAdult,
                SubAuthor = model.SubAuthor,
                Publishor = model.Publishor,
                Artist = model.Artist,
                Translator = model.Translator
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete("{mangaId}")]
        public async Task<IActionResult> Delete(long mangaId)
        {
            var query = new DeleteMangaCommand(mangaId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
