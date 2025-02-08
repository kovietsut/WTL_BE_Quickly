namespace Domain.Entities;

public partial class Session : EntityBase<long>
{
    public long UserId { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public virtual User User { get; set; } = null!;
}
