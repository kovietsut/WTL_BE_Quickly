using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.Delete
{
    public class DeleteMangaCommand(string id) : IRequest<IActionResult>
    {
        public string Id { get; private set; } = id;
    }

    public class DeleteMangaCommandHandler : IRequestHandler<DeleteMangaCommand, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteMangaCommandHandler(IMangaRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteMangaCommand query, CancellationToken cancellationToken)
        {
            var user = await _repository.DeleteMangaAsync(query.Id);
            if (user == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Manga does not exist");
            }
            return JsonUtil.Success(user.Id);
        }
    }
}
