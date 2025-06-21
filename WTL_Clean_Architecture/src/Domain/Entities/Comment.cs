namespace Domain.Entities;

public partial class Comment : EntityBase<string>
{
    public string? MangaId { get; set; }

    public required string UserId { get; set; }

    public string? ParentCommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsSpoiler { get; set; }

    public string? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();

    public virtual ICollection<Comment> InverseParentComment { get; set; } = new List<Comment>();

    public virtual Manga? Manga { get; set; }

    public virtual Comment? ParentComment { get; set; }
}
