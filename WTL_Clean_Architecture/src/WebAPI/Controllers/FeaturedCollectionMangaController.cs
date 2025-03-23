using Application.Features.Chapter.Delete;
using Application.Features.FeaturedCollectionMangas.Delete;
using Application.Features.FeaturedCollections.Create;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeaturedCollectionMangaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturedCollectionMangaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedCollectionMangaAsync([FromBody] CreateFeaturedCollectionMangaDto model)
        {
            var query = new CreateFeaturedCollectionMangaCommand()
            {
                FeaturedCollectionId = model.FeaturedCollectionId,
                MangaId = model.MangaId
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeaturedCollectionMangaAsync(long collectionId, long mangaId)
        {
            var query = new DeleteFeaturedColletionMangaCommand(collectionId, mangaId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
