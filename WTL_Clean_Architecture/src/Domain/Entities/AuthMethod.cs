using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AuthMethod
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? AuthType { get; set; }

    public string? AuthId { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? User { get; set; }
}
