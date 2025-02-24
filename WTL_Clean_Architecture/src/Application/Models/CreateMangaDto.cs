using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateMangaDto
    {
        [Required]
        public required string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int? Format { get; set; }

        public int? Season { get; set; }

        public int? Region { get; set; }

        public int? ReleaseStatus { get; set; }

        public string? Preface { get; set; }

        public bool? HasAdult { get; set; }

        public string? CoverImage { get; set; }

        public long? CreatedBy { get; set; }

        public long? SubAuthor { get; set; }

        public long? Publishor { get; set; }

        public long? Artist { get; set; }

        public long? Translator { get; set; }
    }
}
