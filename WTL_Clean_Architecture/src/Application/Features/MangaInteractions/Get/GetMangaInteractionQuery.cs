using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.MangaInteractions.Get
{
    public class GetMangaInteractionQuery : IRequest<IActionResult>
    {
        public required string UserId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public MangaInteractionType? InteractionType { get; set; }
    }

    public class GetMangaInteractionQueryHandler : IRequestHandler<GetMangaInteractionQuery, IActionResult>
    {
        private readonly IMangaInteractionRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetMangaInteractionQueryHandler(
            IMangaInteractionRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetMangaInteractionQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var mangaInteraction = await _repository.GetMangaInteractionByUserAndContentAsync(
                    query.UserId,
                    query.MangaId,
                    query.ChapterId,
                    query.InteractionType);

                if (mangaInteraction == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound,
                        _errorCodes?.Status404?.NotFound ?? "NotFound",
                        "Manga interaction not found");
                }

                return JsonUtil.Success(mangaInteraction);
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