using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Chapter
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string Name { get; set; } = null!;

    public string? NovelContent { get; set; }

    public bool? HasDraft { get; set; }

    public string? ThumbnailImage { get; set; }

    public DateTime? PublishedDate { get; set; }

    public bool? HasComment { get; set; }

    public int? StatusChapter { get; set; }

    public virtual ICollection<ChapterImage> ChapterImages { get; set; } = new List<ChapterImage>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<MangaInteraction> MangaInteractions { get; set; } = new List<MangaInteraction>();

    public virtual User? ModifiedByNavigation { get; set; }
}
