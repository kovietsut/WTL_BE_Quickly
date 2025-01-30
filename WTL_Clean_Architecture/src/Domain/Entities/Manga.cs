using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class Manga : IEntityBase<long>
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? PublishedDate { get; set; }

    public int? Format { get; set; }

    public int? Season { get; set; }

    public int? Region { get; set; }

    public int? ReleaseStatus { get; set; }

    public string? Preface { get; set; }

    public bool? HasAdult { get; set; }

    public string? CoverImage { get; set; }

    public long? CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public long? SubAuthor { get; set; }

    public long? Publishor { get; set; }

    public long? Artist { get; set; }

    public long? Translator { get; set; }

    public virtual User? ArtistNavigation { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FeaturedCollectionManga> FeaturedCollectionMangas { get; set; } = new List<FeaturedCollectionManga>();

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();

    public virtual ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();

    public virtual ICollection<MangaInteraction> MangaInteractions { get; set; } = new List<MangaInteraction>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User? PublishorNavigation { get; set; }

    public virtual User? SubAuthorNavigation { get; set; }

    public virtual User? TranslatorNavigation { get; set; }
}
