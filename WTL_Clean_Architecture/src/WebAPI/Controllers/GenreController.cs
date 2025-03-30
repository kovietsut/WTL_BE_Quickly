using Application.Features.Genres.Create;
using Application.Features.Genres.Delete;
using Application.Features.Genres.GetById;
using Application.Features.Genres.GetList;
using Application.Features.Genres.Update;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{genreId}")]
        public async Task<IActionResult> Get(int genreId)
        {
            var query = new GetGenreByIdQuery(genreId);
            var result = await _mediator.Send(query);
            return result;
        }

        [AllowAnonymous]
        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var query = new GetListGenreQuery(pageNumber, pageSize, searchText);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync([FromBody] CreateGenreDto model)
        {
            var query = new CreateGenreCommand()
            {
                Name = model.Name
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{genreId}")]
        public async Task<IActionResult> UpdateGenreAsync(long genreId, [FromBody] UpdateGenreDto model)
        {
            var query = new UpdateGenreCommand()
            {
                Id = genreId,
                Name = model.Name
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> DeleteUserAsync(long genreId)
        {
            var query = new DeleteGenreCommand(genreId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
