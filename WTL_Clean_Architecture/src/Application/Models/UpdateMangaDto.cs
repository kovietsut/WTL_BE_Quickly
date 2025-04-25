using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class UpdateMangaDto
    {
        public string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public MangaFormat? Format { get; set; }

        public MangaRegion? Region { get; set; }

        public MangaReleaseStatus? ReleaseStatus { get; set; }

        public string? Preface { get; set; }

        public bool? HasAdult { get; set; }

        public IFormFile? CoverImageFile { get; set; }

        public long? SubAuthor { get; set; }

        public long? Publishor { get; set; }

        public long? Artist { get; set; }

        public long? Translator { get; set; }

        public List<long>? GenreIds { get; set; }
    }
}
