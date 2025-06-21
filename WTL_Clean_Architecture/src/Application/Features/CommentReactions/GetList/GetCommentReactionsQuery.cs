using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.CommentReactions.GetList
{
    public class GetCommentReactionsQuery : IRequest<IActionResult>
    {
        public required string CommentId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetCommentReactionsQueryHandler : IRequestHandler<GetCommentReactionsQuery, IActionResult>
    {
        private readonly ICommentReactionRepository _repository;
        private readonly ICommentRepository _commentRepository;
        private readonly ErrorCode _errorCodes;

        public GetCommentReactionsQueryHandler(
            ICommentReactionRepository repository,
            ICommentRepository commentRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _commentRepository = commentRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetCommentReactionsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                // Check if comment exists
                var comment = await _commentRepository.GetCommendByIdAsync(query.CommentId);
                if (comment == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Comment not found");
                }

                // Validate pagination parameters
                if (query.PageNumber.HasValue && query.PageNumber.Value < 1)
                {
                    query.PageNumber = 1;
                }
                
                if (query.PageSize.HasValue && query.PageSize.Value < 1)
                {
                    query.PageSize = 10;
                }

                var (items, totalCount) = await _repository.GetListByCommentIdAsync(
                    query.CommentId,
                    query.PageNumber,
                    query.PageSize);

                return JsonUtil.Success(new { items, totalCount });
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
} 