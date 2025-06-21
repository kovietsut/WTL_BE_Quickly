using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Users.GetList
{
    public class GetListUserQuery(int? pageNumber, int? pageSize, string? searchText, string? roleId) : IRequest<IActionResult>
    {
        public string? SearchText { get; set; } = searchText;
        public int? PageNumber { get; set; } = pageNumber;
        public int? PageSize { get; set; } = pageSize;
        public string? RoleId { get; set; } = roleId;
    }

    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, IActionResult>
    {
        private readonly IUserRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetListUserQueryHandler(IUserRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetListUserQuery query, CancellationToken cancellationToken)
        {
            query.PageNumber ??= 1; query.PageSize ??= 10;
            var list = await _repository.GetList(query.PageNumber, query.PageSize, query.SearchText, query.RoleId);
            var listData = list.Select(x => new
            {
                x.Id,
                x.IsDeleted,
                x.RoleId,
                x.Email,
                x.FullName,
                x.PhoneNumber,
                x.Address,
            });
            if (listData != null)
            {
                var totalRecords = await _repository.CountAsync();
                return JsonUtil.Success(listData, dataCount: totalRecords);
            }
            return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Empty List Data");
        }
    }
}
