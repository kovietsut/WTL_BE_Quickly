using Application.Features.FeaturedCollectionPermissions.Create;
using Application.Features.FeaturedCollectionPermissions.Delete;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeaturedCollectionPermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturedCollectionPermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedCollectionPermissionAsync([FromBody] CreateFeaturedCollectionPermissionDto model)
        {
            var query = new CreateFeaturedCollectionPermissionCommand()
            {
                UserIds = model.UserIds,
                FeaturedCollectionId = model.FeaturedCollectionId,
                PermissionType = model.PermissionType
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeaturedCollectionMangaAsync(long collectionId, List<long> userIds)
        {
            var query = new DeleteFeaturedCollectionPermissionCommand(collectionId, userIds);
            var result = await _mediator.Send(query);
            return result;
        }
    }
} 
