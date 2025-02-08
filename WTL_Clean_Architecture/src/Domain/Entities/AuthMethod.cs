namespace Domain.Entities;

public partial class AuthMethod : EntityBase<long>
{
    public long? UserId { get; set; }

    public string? AuthType { get; set; }

    public string? AuthId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public DateTime? AccessTokenExpiration { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }

    public bool IsRevoked { get; set; }

    public string? JwtId { get; set; }

    public virtual User? User { get; set; }
}
