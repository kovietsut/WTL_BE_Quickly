using Domain.Enums;

namespace Application.Models
{
    public class CreateFeaturedCollectionPermissionDto
    {
        public List<string> UserIds { get; set; } = new();

        public required string FeaturedCollectionId { get; set; }

        public CollectionPermissionType PermissionType { get; set; }
    }
}
