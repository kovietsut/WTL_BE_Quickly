namespace Domain.Entities;

public partial class Action : EntityBase<long>
{
    public long Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();
}
