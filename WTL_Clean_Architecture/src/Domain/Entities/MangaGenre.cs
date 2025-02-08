namespace Domain.Entities;

public partial class MangaGenre : EntityBase<long>
{
    public long MangaId { get; set; }

    public long GenreId { get; set; }

    public virtual Genere Genre { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
