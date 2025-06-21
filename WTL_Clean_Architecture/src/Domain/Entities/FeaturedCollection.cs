namespace Domain.Entities;

public partial class FeaturedCollection : EntityBase<string>
{
    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public string? CoverImage { get; set; }

    public bool? IsPublish { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FeaturedCollectionManga> FeaturedCollectionMangas { get; set; } = new List<FeaturedCollectionManga>();

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();

    public virtual User? ModifiedByNavigation { get; set; }
}
