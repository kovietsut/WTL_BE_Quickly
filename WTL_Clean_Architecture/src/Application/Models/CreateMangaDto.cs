using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateMangaDto
    {
        [Required]
        public required string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public MangaFormatDto? Format { get; set; }

        public MangaSeasonDto? Season { get; set; }

        public MangaRegionDto? Region { get; set; }

        public MangaReleaseStatusDto? ReleaseStatus { get; set; }

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
