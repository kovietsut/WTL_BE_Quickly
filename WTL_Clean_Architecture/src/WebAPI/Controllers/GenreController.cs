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
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{genreId}")]
        public async Task<IActionResult> Get(string genreId)
        {
            var query = new GetGenreByIdQuery(genreId);
            var result = await _mediator.Send(query);
            return result;
        }

        [AllowAnonymous]
        [HttpGet]
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
        public async Task<IActionResult> UpdateGenreAsync(string genreId, [FromBody] UpdateGenreDto model)
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
        public async Task<IActionResult> DeleteUserAsync(string genreId)
        {
            var query = new DeleteGenreCommand(genreId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
