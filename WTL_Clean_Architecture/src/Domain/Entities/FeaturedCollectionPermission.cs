using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class FeaturedCollectionPermission : IEntityBase<long>
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public long? MangaId { get; set; }

    public long? UserId { get; set; }

    public long? FeaturedCollectionId { get; set; }

    public long? ActionId { get; set; }

    public int PermissionType { get; set; }

    public virtual Action? Action { get; set; }

    public virtual FeaturedCollection? FeaturedCollection { get; set; }

    public virtual Manga? Manga { get; set; }

    public virtual User? User { get; set; }
}
