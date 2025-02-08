namespace Domain.Entities;

public partial class Genere : EntityBase<long>
{
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();
}
