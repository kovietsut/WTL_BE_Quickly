using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class Genere : IEntityBase<long>
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();
}
