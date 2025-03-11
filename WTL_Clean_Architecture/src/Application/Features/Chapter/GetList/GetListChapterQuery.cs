using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Chapter.GetList
{
    public class GetListChapterQuery(int? pageNumber, int? pageSize, string? searchText) : IRequest<IActionResult>
    {
        public string? SearchText { get; set; } = searchText;
        public int? PageNumber { get; set; } = pageNumber;
        public int? PageSize { get; set; } = pageSize;
    }

    public class GetListChapterQueryHandler : IRequestHandler<GetListChapterQuery, IActionResult>
    {
        private readonly IChapterRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetListChapterQueryHandler(IChapterRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetListChapterQuery query, CancellationToken cancellationToken)
        {
            query.PageNumber ??= 1; query.PageSize ??= 10;
            var list = await _repository.GetList(query.PageNumber, query.PageSize, query.SearchText);
            var listData = list.Select(x => new
            {
                x.Id,
                x.Name,
                x.ThumbnailImage,
                x.PublishedDate
            });
            var totalRecords = await _repository.CountAsync();
            if (listData != null)
            {
                return JsonUtil.Success(listData, dataCount: totalRecords);
            }
            return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Empty List Data");
        }
    }
}
