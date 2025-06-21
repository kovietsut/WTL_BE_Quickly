namespace Application.Models
{
    public class CreateChapterDto
    {
        public required string MangaId { get; set; }
        public required string Name { get; set; }

        public string? NovelContent { get; set; }

        public bool? HasDraft { get; set; }

        public string? ThumbnailImage { get; set; }

        public DateTime? PublishedDate { get; set; }

        public bool? HasComment { get; set; }

        public int? StatusChapter { get; set; }

        public required List<ChapterImageDto> ImageList { get; set; }
    }
}
