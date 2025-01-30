using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class MangaGenre : IEntityBase<long>
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }

    public long MangaId { get; set; }

    public long GenreId { get; set; }

    public virtual Genere Genre { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
