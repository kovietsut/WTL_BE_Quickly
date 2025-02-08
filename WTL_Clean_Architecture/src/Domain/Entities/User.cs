namespace Domain.Entities;

public partial class User : EntityBase<long>
{
    public long Id { get; set; }

    public long RoleId { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string? Avatar { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? Gender { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public virtual ICollection<AuthMethod> AuthMethods { get; set; } = new List<AuthMethod>();

    public virtual ICollection<Chapter> ChapterCreatedByNavigations { get; set; } = new List<Chapter>();

    public virtual ICollection<ChapterImage> ChapterImageCreatedByNavigations { get; set; } = new List<ChapterImage>();

    public virtual ICollection<ChapterImage> ChapterImageModifiedByNavigations { get; set; } = new List<ChapterImage>();

    public virtual ICollection<Chapter> ChapterModifiedByNavigations { get; set; } = new List<Chapter>();

    public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();

    public virtual ICollection<FeaturedCollection> FeaturedCollectionCreatedByNavigations { get; set; } = new List<FeaturedCollection>();

    public virtual ICollection<FeaturedCollection> FeaturedCollectionModifiedByNavigations { get; set; } = new List<FeaturedCollection>();

    public virtual ICollection<FeaturedCollectionPermission> FeaturedCollectionPermissions { get; set; } = new List<FeaturedCollectionPermission>();

    public virtual ICollection<Manga> MangaArtistNavigations { get; set; } = new List<Manga>();

    public virtual ICollection<Manga> MangaCreatedByNavigations { get; set; } = new List<Manga>();

    public virtual ICollection<MangaInteraction> MangaInteractions { get; set; } = new List<MangaInteraction>();

    public virtual ICollection<Manga> MangaModifiedByNavigations { get; set; } = new List<Manga>();

    public virtual ICollection<Manga> MangaPublishorNavigations { get; set; } = new List<Manga>();

    public virtual ICollection<Manga> MangaSubAuthorNavigations { get; set; } = new List<Manga>();

    public virtual ICollection<Manga> MangaTranslatorNavigations { get; set; } = new List<Manga>();

    public virtual Role Role { get; set; } = null!;
}
