using Domain.Enums;

namespace Domain.Entities;

public partial class FeaturedCollectionPermission : EntityBase<long>
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public long? UserId { get; set; }

    public long? FeaturedCollectionId { get; set; }

    public CollectionPermissionType PermissionType { get; set; }

    public virtual FeaturedCollection? FeaturedCollection { get; set; }

    public virtual User? User { get; set; }
}
