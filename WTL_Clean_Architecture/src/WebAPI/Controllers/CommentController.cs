using Application.Features.Comments.Commands.Create;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto model)
        {
            var command = new CreateCommentCommand
            {
                MangaId = model.MangaId,
                UserId = model.UserId,
                ParentCommentId = model.ParentCommentId,
                Content = model.Content,
                IsSpoiler = model.IsSpoiler,
                ChapterId = model.ChapterId
            };
            
            var result = await _mediator.Send(command);
            return result;
        }
    }
} 