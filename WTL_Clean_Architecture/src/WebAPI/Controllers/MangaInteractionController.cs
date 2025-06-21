using Application.Features.MangaInteractions.Create;
using Application.Features.MangaInteractions.Delete;
using Application.Features.MangaInteractions.Get;
using Application.Features.MangaInteractions.GetById;
using Application.Features.MangaInteractions.GetList;
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
        public async Task<IActionResult> GetMangaInteractionById([FromQuery] string userId, [FromQuery] string? mangaId, [FromQuery] string? chapterId, [FromQuery] MangaInteractionType? interactionType)
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
        public async Task<IActionResult> GetMangaInteraction([FromQuery] string userId, [FromQuery] string? mangaId, [FromQuery] string? chapterId, [FromQuery] MangaInteractionType? interactionType)
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

        [HttpGet("list")]
        public async Task<IActionResult> GetMangaInteractionList(
            [FromQuery] string userId, 
            [FromQuery] string? mangaId = null, 
            [FromQuery] string? chapterId = null, 
            [FromQuery] MangaInteractionType? interactionType = null, 
            [FromQuery] int? pageNumber = 1, 
            [FromQuery] int? pageSize = 10)
        {
            // Validate pagination parameters
            if (pageNumber.HasValue && pageNumber.Value < 1)
            {
                pageNumber = 1;
            }
            
            if (pageSize.HasValue && pageSize.Value < 1)
            {
                pageSize = 10;
            }
            
            var query = new GetMangaInteractionListQuery
            {
                UserId = userId,
                MangaId = mangaId,
                ChapterId = chapterId,
                InteractionType = interactionType,
                PageNumber = pageNumber,
                PageSize = pageSize
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
        public async Task<IActionResult> DeleteMangaInteraction([FromQuery] string? mangaId, [FromQuery] string? chapterId)
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
