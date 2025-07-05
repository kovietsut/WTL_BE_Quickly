using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.Features.FeaturedCollections.Create
{
    public class CreateFeaturedCollectionCommand : IRequest<IActionResult>
    {
        public required string Name { get; set; }
        public string? CoverImage { get; set; }
        public bool? IsPublish { get; set; }
    }

    public class CreateFeaturedCollectionCommandHandler : IRequestHandler<CreateFeaturedCollectionCommand, IActionResult>
    {
        private readonly IFeaturedCollectionRepository _repository;
        private readonly ErrorCode _errorCodes;
        private readonly IAuthenticationRepository _authRepository;
        private readonly IFeaturedCollectionPermissionRepository _permissionRepository;

        public CreateFeaturedCollectionCommandHandler(
            IFeaturedCollectionRepository repository, 
            IOptions<ErrorCode> errorCodes,
            IAuthenticationRepository authRepository,
            IFeaturedCollectionPermissionRepository permissionRepository)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
            _authRepository = authRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<IActionResult> Handle(CreateFeaturedCollectionCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var currentUserId = _authRepository.GetUserId();
                
                // Validate that we have a valid user ID
                if (string.IsNullOrEmpty(currentUserId))
                {
                    return JsonUtil.Error(StatusCodes.Status401Unauthorized, _errorCodes?.Status401?.Unauthorized ?? "Unauthorized", "User not authenticated");
                }
                
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

                var userIds = new List<string> { currentUserId };
                var collection = await _repository.CreateFeaturedCollectionAsync(createCollectionDto);
                var permission = await _permissionRepository.CreateListFeaturedCollectionPermissionAsync(new CreateFeaturedCollectionPermissionDto {
                    UserIds = userIds,
                    FeaturedCollectionId = collection.Id,
                    PermissionType = CollectionPermissionType.Write
                });
                return JsonUtil.Success(collection.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
