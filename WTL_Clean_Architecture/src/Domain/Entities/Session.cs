using Domain.Entities.Interfaces;

namespace Domain.Entities;

public partial class Session : IEntityBase<long>
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User User { get; set; } = null!;
}
