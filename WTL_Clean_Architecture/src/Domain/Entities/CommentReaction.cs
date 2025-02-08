namespace Domain.Entities;

public partial class CommentReaction : EntityBase<long>
{
    public long Id { get; set; }

    public long CommentId { get; set; }

    public long UserId { get; set; }

    public int ReactionType { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Reason { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
