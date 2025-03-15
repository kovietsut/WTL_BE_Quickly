using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Create
{
    public class CreateFeaturedCollectionCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string? CoverImage { get; set; }
        public bool? IsPublish { get; set; }
    }

    public class CreateFeaturedCollectionCommandHandler(IFeaturedCollectionRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateFeaturedCollectionCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateFeaturedCollectionCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createCollectionDto = new CreateFeaturedCollectionDto
                {
                    Name = query.Name,
                    CoverImage = query.CoverImage,
                    IsPublish = query.IsPublish
                };
                var validator = new CreateFeaturedCollectionValidator();
                var check = await validator.ValidateAsync(createCollectionDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var collection = await repository.CreateFeaturedCollectionAsync(createCollectionDto);
                return JsonUtil.Success(collection.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
