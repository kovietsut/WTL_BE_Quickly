using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Genres.GetList
{
    public class GetListGenreQuery(int? pageNumber, int? pageSize, string? searchText) : IRequest<IActionResult>
    {
        public string? SearchText { get; set; } = searchText;
        public int? PageNumber { get; set; } = pageNumber;
        public int? PageSize { get; set; } = pageSize;
    }

    public class GetListGenreQueryHandler : IRequestHandler<GetListGenreQuery, IActionResult>
    {
        private readonly IGenreRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetListGenreQueryHandler(IGenreRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetListGenreQuery query, CancellationToken cancellationToken)
        {
            query.PageNumber ??= 1; query.PageSize ??= 10;
            var list = await _repository.GetList(query.PageNumber, query.PageSize, query.SearchText);
            var listData = list.Select(x => new
            {
                x.Id,
                x.Name
            });
            if (listData != null)
            {
                var totalRecords = listData.Count();
                return JsonUtil.Success(listData, dataCount: totalRecords);
            }
            return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Empty List Data");
        }
    }
}
