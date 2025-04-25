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

        public long? CreatedBy { get; set; }

        public long? SubAuthor { get; set; }

        public long? Publishor { get; set; }

        public long? Artist { get; set; }

        public long? Translator { get; set; }

        public List<long>? GenreIds { get; set; }
    }
}
