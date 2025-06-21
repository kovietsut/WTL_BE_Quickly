namespace Domain.Entities;

public partial class Genere : EntityBase<string>
{
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();
}
