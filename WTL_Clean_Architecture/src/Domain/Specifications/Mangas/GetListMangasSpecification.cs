using Domain.Entities;
using Domain.Mappers;
using Domain.SpecificationModels;

namespace Domain.Specifications.Mangas
{
    public class GetListMangasSpecification : Specification<Manga, long>
    {
        public GetListMangasSpecification(MangaFilterDto filter, bool includePaging = true) :
            base(manga => manga.IsDeleted != true &&
            (string.IsNullOrEmpty(filter.SearchTerm) || (manga.Title != null && manga.Title.Contains(filter.SearchTerm.Trim()))) &&
            (!filter.Format.HasValue || manga.Format == MangaMapper.ToDomainFormat(filter.Format)) &&
            (!filter.Region.HasValue || manga.Region == MangaMapper.ToDomainRegion(filter.Region)) &&
            (!filter.ReleaseStatus.HasValue || manga.ReleaseStatus == MangaMapper.ToDomainReleaseStatus(filter.ReleaseStatus)) &&
            (filter.GenreIds == null || !filter.GenreIds.Any() || manga.MangaGenres.Any(mg => filter.GenreIds.Contains(mg.GenreId) && mg.IsDeleted != true)))
        {
            if (includePaging)
            {
                ApplyPaging((filter.PageNumber - 1) * filter.PageSize, filter.PageSize);
            }
            AddOrderByDescending(u => u.Id);

            AddInclude("MangaGenres.Genre");
            AddInclude(m => m.SubAuthorNavigation);
            AddInclude(m => m.ArtistNavigation);
            AddInclude(m => m.TranslatorNavigation);
            AddInclude(m => m.PublishorNavigation);
            AddInclude(m => m.Chapters.OrderByDescending(c => c.Id).Take(1));

            IsSplitQuery = true;
        }
    }
}
