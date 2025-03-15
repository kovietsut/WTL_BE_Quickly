using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Update
{
    public class UpdateFeaturedCollectionCommand : IRequest<IActionResult>
    {
        public required long Id { get; set; }
        public string Name { get; set; }
        public string? CoverImage { get; set; }
        public bool? IsPublish { get; set; }
    }
    public class UpdateFeaturedCollectionCommandHandler : IRequestHandler<UpdateFeaturedCollectionCommand, IActionResult>
    {
        private readonly IFeaturedCollectionRepository _repository;
        private readonly ErrorCode _errorCodes;

        public UpdateFeaturedCollectionCommandHandler(IFeaturedCollectionRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(UpdateFeaturedCollectionCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var updateCollectionDto = new UpdateFeaturedCollectionDto
                {
                    Name = query.Name,
                    CoverImage = query.CoverImage,
                    IsPublish = query.IsPublish
                };
                var validator = new UpdateFeaturedCollectionValidator();
                var check = await validator.ValidateAsync(updateCollectionDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }
                var currentChapter = await _repository.GetByIdAsync(query.Id);
                if (currentChapter == null)
                {
                    return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Collection does not exist");
                }
                var chapter = await _repository.UpdateFeaturedCollectionAsync(query.Id, updateCollectionDto);
                return JsonUtil.Success(chapter.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
