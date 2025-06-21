namespace Application.Models
{
    public class ChapterImageDto
    {
        public required string Name { get; set; }

        public string? FileSize { get; set; }

        public string? MimeType { get; set; }

        public string? FilePath { get; set; }
    }
}
