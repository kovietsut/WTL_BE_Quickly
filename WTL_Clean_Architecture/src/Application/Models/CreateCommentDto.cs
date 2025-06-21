namespace Application.Models
{
    public class CreateCommentDto
    {
        public string? MangaId { get; set; }
        public required string UserId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public string? ChapterId { get; set; }
    }
} 