using Domain.Enums;

namespace Domain.Entities;

public partial class CommentReaction : EntityBase<string>
{
    public required string CommentId { get; set; }

    public required string UserId { get; set; }

    public CommentReactionType ReactionType { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Reason { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
