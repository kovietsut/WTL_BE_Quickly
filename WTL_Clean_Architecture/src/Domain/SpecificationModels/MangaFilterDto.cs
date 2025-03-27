using Domain.Enums;

namespace Domain.SpecificationModels
{
    public class MangaFilterDto
    {
        public MangaFormatDto? Format { get; set; }
        public MangaSeasonDto? Season { get; set; }
        public MangaRegionDto? Region { get; set; }
        public MangaReleaseStatusDto? ReleaseStatus { get; set; }
        public List<long>? GenreIds { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}