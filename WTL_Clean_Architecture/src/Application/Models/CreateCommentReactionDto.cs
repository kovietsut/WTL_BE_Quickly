using Domain.Enums;

namespace Application.Models
{
    public class CreateCommentReactionDto
    {
        public long CommentId { get; set; }
        public CommentReactionType ReactionType { get; set; }
        public string? Reason { get; set; }
    }
} 