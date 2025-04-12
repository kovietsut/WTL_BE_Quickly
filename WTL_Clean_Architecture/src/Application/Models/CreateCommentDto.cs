namespace Application.Models
{
    public class CreateCommentDto
    {
        public long? MangaId { get; set; }
        public long UserId { get; set; }
        public long? ParentCommentId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsSpoiler { get; set; }
        public long? ChapterId { get; set; }
    }
} 