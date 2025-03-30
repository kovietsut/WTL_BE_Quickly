using Domain.Enums;

namespace Application.Models
{
    public class CreateFeaturedCollectionPermissionDto
    {
        public List<long> UserIds { get; set; } = new();

        public long FeaturedCollectionId { get; set; }

        public CollectionPermissionType PermissionType { get; set; }
    }
}
