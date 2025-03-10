using Application.Features.Genres.Delete;
using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chapter.Delete
{
    public class DeleteChapterCommand(long id) : IRequest<IActionResult>
    {
        public long Id { get; private set; } = id;
    }

    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand, IActionResult>
    {
        private readonly IChapterRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteChapterCommandHandler(IChapterRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteChapterCommand query, CancellationToken cancellationToken)
        {
            var chapter = await _repository.DeleteChapterAsync(query.Id);
            if (chapter == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Chapter does not exist");
            }
            return JsonUtil.Success(chapter.Id);
        }
    }
}
