namespace Domain.Entities;

public partial class Chapter : EntityBase<long>
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public string Name { get; set; } = null!;

    public string? NovelContent { get; set; }

    public bool? HasDraft { get; set; }

    public string? ThumbnailImage { get; set; }

    public DateTime? PublishedDate { get; set; }

    public bool? HasComment { get; set; }

    public int? StatusChapter { get; set; }

    public long MangaId { get; set; }

    public int ChapterNumber { get; set; }

    public virtual ICollection<ChapterImage> ChapterImages { get; set; } = new List<ChapterImage>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<MangaInteraction> MangaInteractions { get; set; } = new List<MangaInteraction>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Manga Manga { get; set; } = null!;
}
