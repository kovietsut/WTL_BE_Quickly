using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Genres.GetById
{
    public class GetGenreByIdQuery(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, IActionResult>
    {
        private readonly IGenreRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetGenreByIdQueryHandler(IGenreRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetGenreByIdQuery query, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetGenreById(query.Id);
            if (genre == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Genre does not exist");
            }
            var result = new
            {
                genre.Id,
                genre.IsDeleted,
                genre.Name,
                genre.CreatedAt,
                genre.UpdatedAt
            };
            return JsonUtil.Success(result);
        }
    }
}
