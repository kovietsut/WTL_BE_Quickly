using Application.Features.MangaInteractions.Create;
using Application.Features.MangaInteractions.Delete;
using Application.Features.MangaInteractions.Get;
using Application.Features.MangaInteractions.GetById;
using Application.Models;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/manga-interaction")]
    [ApiController]
    [Authorize]
    public class MangaInteractionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangaInteractionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetMangaInteractionById([FromQuery] long userId, [FromQuery] long? mangaId, [FromQuery] long? chapterId, [FromQuery] MangaInteractionType? interactionType)
        {
            var query = new GetMangaInteractionByIdQuery
            {
                UserId = userId,
                MangaId = mangaId,
                ChapterId = chapterId,
                InteractionType = interactionType
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetMangaInteraction([FromQuery] long userId, [FromQuery] long? mangaId, [FromQuery] long? chapterId, [FromQuery] MangaInteractionType? interactionType)
        {
            var query = new GetMangaInteractionQuery
            {
                UserId = userId,
                MangaId = mangaId,
                ChapterId = chapterId,
                InteractionType = interactionType
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMangaInteraction([FromBody] CreateMangaInteractionDto model)
        {
            var command = new CreateMangaInteractionCommand
            {
                MangaId = model.MangaId,
                ChapterId = model.ChapterId,
                InteractionType = model.InteractionType
            };
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMangaInteraction([FromQuery] long? mangaId, [FromQuery] long? chapterId)
        {
            var command = new DeleteMangaInteractionCommand
            {
                MangaId = mangaId,
                ChapterId = chapterId
            };
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
