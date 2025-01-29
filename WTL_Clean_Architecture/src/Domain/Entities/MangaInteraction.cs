using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class MangaInteraction
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid? MangaId { get; set; }

    public Guid? ChapterId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public int? InteractionType { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual Manga? Manga { get; set; }

    public virtual User User { get; set; } = null!;
}
