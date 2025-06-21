using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.Manga.UploadCover
{
    public class UploadMangaCoverCommand : IRequest<IActionResult>
    {
        public required string MangaId { get; set; }
        public required IFormFile CoverImageFile { get; set; }
    }

    public class UploadMangaCoverCommandHandler : IRequestHandler<UploadMangaCoverCommand, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly ErrorCode _errorCodes;

        public UploadMangaCoverCommandHandler(
            IMangaRepository repository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UploadMangaCoverCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var uploadMangaCoverDto = new UploadMangaCoverDto
                {
                    MangaId = command.MangaId,
                    CoverImageFile = command.CoverImageFile
                };

                var validator = new UploadMangaCoverValidator();
                var validationResult = await validator.ValidateAsync(uploadMangaCoverDto, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, 
                        _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", 
                        validationResult.Errors);
                }

                var coverImageUrl = await _repository.UploadCoverImageAsync(command.MangaId, command.CoverImageFile);
                return JsonUtil.Success(StatusCodes.Status200OK, "Cover image saved");
            }
            catch (ArgumentNullException ex)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes?.Status404?.NotFound, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, "An error occurred while uploading the cover image");
            }
        }
    }
} 