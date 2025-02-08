namespace Domain.Entities;

public partial class ChapterImage : EntityBase<long>
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public string Name { get; set; } = null!;

    public string? FileSize { get; set; }

    public string? MimeType { get; set; }

    public string? FilePath { get; set; }

    public long? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
