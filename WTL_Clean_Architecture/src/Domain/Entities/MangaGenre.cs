namespace Domain.Entities;

public partial class MangaGenre : EntityBase<string>
{
    public required string MangaId { get; set; }

    public required string GenreId { get; set; }

    public virtual Genere Genre { get; set; } = null!;

    public virtual Manga Manga { get; set; } = null!;
}
