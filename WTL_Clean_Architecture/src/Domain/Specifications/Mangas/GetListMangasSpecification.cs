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
            (!filter.Season.HasValue || manga.Season == MangaMapper.ToDomainSeason(filter.Season)) &&
            (!filter.Region.HasValue || manga.Region == MangaMapper.ToDomainRegion(filter.Region)) &&
            (!filter.ReleaseStatus.HasValue || manga.ReleaseStatus == MangaMapper.ToDomainReleaseStatus(filter.ReleaseStatus)) &&
            (filter.GenreIds == null || !filter.GenreIds.Any() || manga.MangaGenres.Any(mg => filter.GenreIds.Contains(mg.GenreId))))
        {
            if (includePaging)
            {
                ApplyPaging((filter.Page - 1) * filter.PageSize, filter.PageSize);
            }
            AddOrderByDescending(u => u.CreatedAt);

            // Include related entities
            AddInclude(x => x.MangaGenres);
                AddThenInclude<MangaGenre>(mg => mg.Genre);
            AddInclude(x => x.SubAuthorNavigation);
            AddInclude(x => x.ArtistNavigation);
            AddInclude(x => x.TranslatorNavigation);
            AddInclude(x => x.PublishorNavigation);
        }
    }
}
