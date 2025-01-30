using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class FeaturedCollectionManga : IEntityBase<long>
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }

    public long MangaId { get; set; }

    public long FeaturedCollectionId { get; set; }

    public virtual FeaturedCollection FeaturedCollection { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
