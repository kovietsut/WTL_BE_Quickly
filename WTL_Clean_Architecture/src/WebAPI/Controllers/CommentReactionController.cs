using Application.Features.CommentReactions.Create;
using Application.Features.CommentReactions.GetList;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/comment-reaction")]
    public class CommentReactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCommentReactions(
            [FromQuery] string commentId,
            [FromQuery] int? pageNumber = 1,
            [FromQuery] int? pageSize = 10)
        {
            var query = new GetCommentReactionsQuery
            {
                CommentId = commentId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentReaction([FromBody] CreateCommentReactionDto model)
        {
            var command = new CreateCommentReactionCommand
            {
                CommentId = model.CommentId,
                ReactionType = model.ReactionType,
                Reason = model.Reason
            };
            
            var result = await _mediator.Send(command);
            return result;
        }
    }
} 