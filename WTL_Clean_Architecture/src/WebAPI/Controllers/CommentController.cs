using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.GetList;
using Application.Features.Comments.Update;
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

        [HttpGet("list")]
        public async Task<IActionResult> GetList(
            [FromQuery] long? mangaId = null,
            [FromQuery] long? chapterId = null,
            [FromQuery] long? parentCommentId = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetListCommentQuery
            {
                MangaId = mangaId,
                ChapterId = chapterId,
                ParentCommentId = parentCommentId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            
            var result = await _mediator.Send(query);
            return result;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(long id, [FromBody] UpdateCommentDto model)
        {
            var command = new UpdateCommentCommand
            {
                Id = id,
                Content = model.Content,
                IsSpoiler = model.IsSpoiler
            };
            
            var result = await _mediator.Send(command);
            return result;
        }
    }
} 