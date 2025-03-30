using Domain.Enums;

namespace Domain.SpecificationModels
{
    public class MangaFilterDto
    {
        public MangaFormat? Format { get; set; }
        public MangaRegion? Region { get; set; }
        public MangaReleaseStatus? ReleaseStatus { get; set; }
        public List<long>? GenreIds { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}