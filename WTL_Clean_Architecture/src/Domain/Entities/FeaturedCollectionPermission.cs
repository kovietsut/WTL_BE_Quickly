using Domain.Enums;

namespace Domain.Entities;

public partial class FeaturedCollectionPermission : EntityBase<string>
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string? UserId { get; set; }

    public string? FeaturedCollectionId { get; set; }

    public CollectionPermissionType PermissionType { get; set; }

    public virtual FeaturedCollection? FeaturedCollection { get; set; }

    public virtual User? User { get; set; }
}
