using Domain.Enums;

namespace Domain.Entities;

public partial class MangaInteraction : EntityBase<long>
{
    public long UserId { get; set; }

    public long? MangaId { get; set; }

    public long? ChapterId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public MangaInteractionType? InteractionType { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual Manga? Manga { get; set; }

    public virtual User User { get; set; } = null!;
}
