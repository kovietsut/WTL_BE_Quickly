namespace Domain.Entities;

public partial class MangaInteraction : EntityBase<long>
{
    public long UserId { get; set; }

    public long? MangaId { get; set; }

    public long? ChapterId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? InteractionType { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual Manga? Manga { get; set; }

    public virtual User User { get; set; } = null!;
}
