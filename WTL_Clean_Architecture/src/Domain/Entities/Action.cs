namespace Domain.Entities;

public partial class Action : EntityBase<long>
{
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();
}
