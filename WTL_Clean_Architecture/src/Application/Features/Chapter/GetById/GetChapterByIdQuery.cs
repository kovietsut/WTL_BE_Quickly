using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Chapter.GetById
{
    public class GetChapterByIdQuery(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class GetChapterByIdQueryHandler : IRequestHandler<GetChapterByIdQuery, IActionResult>
    {
        private readonly IChapterRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetChapterByIdQueryHandler(IChapterRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetChapterByIdQuery query, CancellationToken cancellationToken)
        {
            var chapter = await _repository.GetChapterById(query.Id);
            if (chapter == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, "Chapter does not exist");
            }

            var result = new
            {
                chapter.Id,
                chapter.IsDeleted,
                chapter.Name,
                chapter.CreatedAt,
                chapter.UpdatedAt,
                chapter.ChapterImages
            };
            return JsonUtil.Success(result);
        }
    }
}
