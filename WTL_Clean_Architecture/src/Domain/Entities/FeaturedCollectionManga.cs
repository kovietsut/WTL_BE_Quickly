namespace Domain.Entities;

public partial class FeaturedCollectionManga : EntityBase<long>
{
    public long MangaId { get; set; }

    public long FeaturedCollectionId { get; set; }

    public virtual FeaturedCollection FeaturedCollection { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
