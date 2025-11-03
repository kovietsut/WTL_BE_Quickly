using Application.Features.FeaturedCollections.Create;
using Application.Features.FeaturedCollections.Delete;
using Application.Features.FeaturedCollections.GetById;
using Application.Features.FeaturedCollections.GetList;
using Application.Features.FeaturedCollections.Update;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeaturedCollectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturedCollectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var query = new GetListFeaturedCollectionQuery(pageNumber, pageSize, searchText);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetFeaturedCollectionByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedCollectionAsync([FromBody] CreateFeaturedCollectionDto model)
        {
            var query = new CreateFeaturedCollectionCommand()
            {
                Name = model.Name,
                CoverImage = model.CoverImage,
                IsPublish = model.IsPublish
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{chapterId}")]
        public async Task<IActionResult> UpdateFeaturedCollectionAsync(string chapterId, [FromBody] UpdateFeaturedCollectionDto model)
        {
            var query = new UpdateFeaturedCollectionCommand()
            {
                Id = chapterId,
                Name = model.Name,
                CoverImage = model.CoverImage,
                IsPublish = model.IsPublish
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete("{collectionId}")]
        public async Task<IActionResult> DeleteFeaturedCollectionAsync(string collectionId)
        {
            var query = new DeleteFeaturedCollectionCommand(collectionId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
