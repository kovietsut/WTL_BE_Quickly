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
        public required IFormFile CoverImage { get; set; }
    }

    public class UploadMangaCoverCommandHandler : IRequestHandler<UploadMangaCoverCommand, IActionResult>
    {
        private readonly IMangaRepository _repository;
        private readonly ErrorCode _errorCodes;
        private readonly IAzureBlobRepository _azureBlobRepository;
        public UploadMangaCoverCommandHandler(
            IMangaRepository repository,
            IAzureBlobRepository azureBlobRepository,
            IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
            _azureBlobRepository = azureBlobRepository;
        }

        public async Task<IActionResult> Handle(UploadMangaCoverCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var uploadMangaCoverDto = new UploadMangaCoverDto
                {
                    MangaId = command.MangaId,
                    CoverImageFile = command.CoverImage
                };

                var validator = new UploadMangaCoverValidator();
                var validationResult = await validator.ValidateAsync(uploadMangaCoverDto, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, 
                        _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", 
                        validationResult.Errors);
                }

                var uploadResult = await _azureBlobRepository.UploadFile(uploadMangaCoverDto.CoverImageFile, "test");
                
                // Extract file path from the upload result
                if (uploadResult is ObjectResult objectResult && objectResult.StatusCode == 200)
                {
                    var responseData = objectResult.Value;
                    string? filePath = null;
                    
                    // The JsonUtil.Success wraps data in a structure with 'data' property
                    if (responseData != null)
                    {
                        var responseType = responseData.GetType();
                        var dataProperty = responseType.GetProperty("data");
                        if (dataProperty != null)
                        {
                            var data = dataProperty.GetValue(responseData);
                            if (data != null)
                            {
                                var dataType = data.GetType();
                                var filePathProperty = dataType.GetProperty("FilePath");
                                if (filePathProperty != null)
                                {
                                    filePath = filePathProperty.GetValue(data)?.ToString();
                                }
                            }
                        }
                    }
                    
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        var coverImageUrl = await _repository.UploadCoverImageAsync(uploadMangaCoverDto.MangaId, filePath);
                        return JsonUtil.Success(new
                        {
                            Message = "Cover image uploaded successfully",
                            CoverImageUrl = coverImageUrl
                        });
                    }
                }
                
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, "Failed to upload file to blob storage");
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
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, "An error occurred while uploading the cover image: " + ex.Message);
            }
        }
    }
} 