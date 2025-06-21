using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class CreateMangaDto
    {
        [Required]
        public required string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public MangaFormat? Format { get; set; }

        public MangaRegion? Region { get; set; }

        public MangaReleaseStatus? ReleaseStatus { get; set; }

        public string? Preface { get; set; }

        public bool? HasAdult { get; set; }

        public string? CreatedBy { get; set; }

        public string? SubAuthor { get; set; }

        public string? Publishor { get; set; }

        public string? Artist { get; set; }

        public string? Translator { get; set; }

        public List<string>? GenreIds { get; set; }
    }
}
