using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class MangaGenre
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public Guid MangaId { get; set; }

    public Guid GenreId { get; set; }

    public virtual Genere Genre { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
