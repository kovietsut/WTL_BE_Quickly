using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Session
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User User { get; set; } = null!;
}
