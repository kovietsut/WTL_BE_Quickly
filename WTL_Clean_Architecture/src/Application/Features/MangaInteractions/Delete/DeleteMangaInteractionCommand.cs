using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.MangaInteractions.Delete
{
    public class DeleteMangaInteractionCommand : IRequest<IActionResult>
    {
        public long? MangaId { get; set; }
        public long? ChapterId { get; set; }
    }

    public class DeleteMangaInteractionCommandHandler : IRequestHandler<DeleteMangaInteractionCommand, IActionResult>
    {
        private readonly IMangaInteractionRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteMangaInteractionCommandHandler(
            IMangaInteractionRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteMangaInteractionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var mangaInteraction = await _repository.DeleteMangaInteractionAsync(
                    command.MangaId,
                    command.ChapterId);

                if (mangaInteraction == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound,
                        _errorCodes?.Status404?.NotFound ?? "NotFound",
                        "Manga interaction not found");
                }

                return JsonUtil.Success(mangaInteraction.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError,
                    _errorCodes?.Status500?.APIServerError,
                    ex.Message);
            }
        }
    }
}
