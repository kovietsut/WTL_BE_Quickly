using Domain.Enums;

namespace Application.Models
{
    public class CreateCommentReactionDto
    {
        public required string CommentId { get; set; }
        public CommentReactionType ReactionType { get; set; }
        public string? Reason { get; set; }
    }
} 