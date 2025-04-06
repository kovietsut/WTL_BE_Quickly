using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.MangaInteractions.Create
{
    public class CreateMangaInteractionCommand : IRequest<IActionResult>
    {
        public long? MangaId { get; set; }
        public long? ChapterId { get; set; }
        public int? InteractionType { get; set; }
    }

    public class CreateMangaInteractionCommandHandler : IRequestHandler<CreateMangaInteractionCommand, IActionResult>
    {
        private readonly IMangaInteractionRepository _repository;
        private readonly IAuthenticationRepository _authRepository;
        private readonly ErrorCode _errorCodes;

        public CreateMangaInteractionCommandHandler(
            IMangaInteractionRepository repository,
            IAuthenticationRepository authRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _authRepository = authRepository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(CreateMangaInteractionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var createMangaInteractionDto = new CreateMangaInteractionDto
                {
                    MangaId = command.MangaId,
                    ChapterId = command.ChapterId,
                    InteractionType = command.InteractionType
                };

                var validator = new CreateMangaInteractionValidator();
                var validationResult = await validator.ValidateAsync(createMangaInteractionDto, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, 
                        _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", 
                        validationResult.Errors);
                }

                // Check for existing interaction
                var userId = _authRepository.GetUserId();
                var existingInteraction = await _repository.GetMangaInteractionByUserAndContentAsync(
                    userId,
                    command.MangaId,
                    command.ChapterId);

                if (existingInteraction != null)
                {
                    return JsonUtil.Error(StatusCodes.Status400BadRequest,
                        _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation",
                        "A manga interaction already exists for this content");
                }

                var result = await _repository.CreateMangaInteractionAsync(createMangaInteractionDto);
                return JsonUtil.Success(result.Id);
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
