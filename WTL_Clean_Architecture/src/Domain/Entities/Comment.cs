using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Comment
{
    public Guid Id { get; set; }

    public Guid? MangaId { get; set; }

    public Guid UserId { get; set; }

    public Guid? ParentCommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsSpoiler { get; set; }

    public Guid? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();

    public virtual ICollection<Comment> InverseParentComment { get; set; } = new List<Comment>();

    public virtual Manga? Manga { get; set; }

    public virtual Comment? ParentComment { get; set; }
}
