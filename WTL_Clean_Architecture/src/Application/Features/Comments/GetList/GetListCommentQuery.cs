using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Comments.GetList
{
    public class GetListCommentQuery : IRequest<IActionResult>
    {
        public long? MangaId { get; set; }
        public long? ChapterId { get; set; }
        public long? ParentCommentId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, IActionResult>
    {
        private readonly ICommentRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetListCommentQueryHandler(
            ICommentRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetListCommentQuery query, CancellationToken cancellationToken)
        {
            try
            {
                // Validate pagination parameters
                if (query.PageNumber < 1)
                {
                    query.PageNumber = 1;
                }
                
                if (query.PageSize < 1)
                {
                    query.PageSize = 10;
                }

                var (items, totalCount) = await _repository.GetListAsync(
                    query.MangaId,
                    query.ChapterId,
                    query.ParentCommentId,
                    query.PageNumber,
                    query.PageSize);

                return JsonUtil.Success(new
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = query.PageNumber,
                    PageSize = query.PageSize
                });
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(
                    StatusCodes.Status500InternalServerError,
                    _errorCodes?.Status500?.APIServerError,
                    ex.Message);
            }
        }
    }
} 