using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CommentReaction
{
    public Guid Id { get; set; }

    public Guid CommentId { get; set; }

    public Guid UserId { get; set; }

    public int ReactionType { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Reason { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
