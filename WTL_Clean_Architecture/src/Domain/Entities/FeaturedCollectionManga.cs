namespace Domain.Entities;

public partial class FeaturedCollectionManga : EntityBase<string>
{
    public required string MangaId { get; set; }

    public required string FeaturedCollectionId { get; set; }

    public virtual FeaturedCollection FeaturedCollection { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
