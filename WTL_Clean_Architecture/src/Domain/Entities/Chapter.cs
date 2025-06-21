namespace Domain.Entities;

public partial class Chapter : EntityBase<string>
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public string Name { get; set; } = null!;

    public string? NovelContent { get; set; }

    public bool? HasDraft { get; set; }

    public string? ThumbnailImage { get; set; }

    public DateTime? PublishedDate { get; set; }

    public bool? HasComment { get; set; }

    public int? StatusChapter { get; set; }

    public required string MangaId { get; set; }

    public int? ChapterNumber { get; set; }

    public virtual ICollection<ChapterImage> ChapterImages { get; set; } = new List<ChapterImage>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<MangaInteraction> MangaInteractions { get; set; } = new List<MangaInteraction>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Manga Manga { get; set; } = null!;
}
