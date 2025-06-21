using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.MangaInteractions.GetList
{
    public class GetMangaInteractionListQuery : IRequest<IActionResult>
    {
        public required string UserId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public MangaInteractionType? InteractionType { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetMangaInteractionListQueryHandler : IRequestHandler<GetMangaInteractionListQuery, IActionResult>
    {
        private readonly IMangaInteractionRepository _repository;
        private readonly ErrorCode _errorCodes;

        public GetMangaInteractionListQueryHandler(
            IMangaInteractionRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(GetMangaInteractionListQuery query, CancellationToken cancellationToken)
        {
            try
            {
                // Validate input parameters
                if (query.UserId == null)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest, 
                        _errorCodes?.Status400?.BadRequest, 
                        "Invalid user ID");
                }

                // Get manga interactions
                var mangaInteractions = await _repository.GetMangaInteractionListAsync(
                    query.UserId,
                    query.MangaId,
                    query.ChapterId,
                    query.InteractionType,
                    query.PageNumber,
                    query.PageSize);

                // Check if any interactions were found
                if (mangaInteractions == null || !mangaInteractions.Any())
                {
                    return JsonUtil.Success(new List<object>(), "No manga interactions found");
                }

                // Return success response with data
                return JsonUtil.Success(mangaInteractions, "Manga interactions retrieved successfully");
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