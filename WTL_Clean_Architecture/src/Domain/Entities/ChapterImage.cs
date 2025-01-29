using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ChapterImage
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public string Name { get; set; } = null!;

    public string? FileSize { get; set; }

    public string? MimeType { get; set; }

    public string? FilePath { get; set; }

    public Guid? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
