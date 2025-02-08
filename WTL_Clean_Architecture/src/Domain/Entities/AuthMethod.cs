namespace Domain.Entities;

public partial class AuthMethod : EntityBase<long>
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? AuthType { get; set; }

    public string? AuthId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public string? JwtId { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime? AccessTokenExpiration { get; set; }

    public DateTime? RefreshTokenExpiration { get; set; }

    public virtual User? User { get; set; }
}
