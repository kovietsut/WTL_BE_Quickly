using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FeaturedCollectionManga
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public Guid MangaId { get; set; }

    public Guid FeaturedCollectionId { get; set; }

    public virtual FeaturedCollection FeaturedCollection { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
