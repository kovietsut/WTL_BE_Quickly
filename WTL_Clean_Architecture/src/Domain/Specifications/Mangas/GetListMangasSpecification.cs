using Domain.Entities;
using Domain.Enums;
using Domain.Mappers;
using Domain.SpecificationModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications.Mangas
{
    public class GetListMangasSpecification : Specification<Manga, string>
    {
        public GetListMangasSpecification(MangaFilterDto filter, bool includePaging = true) :
            base(manga => manga.IsDeleted != true &&
            (string.IsNullOrEmpty(filter.SearchTerm) || (manga.Title != null && manga.Title.Contains(filter.SearchTerm.Trim()))) &&
            (!filter.Format.HasValue || manga.Format == MangaMapper.ToDomainFormat(filter.Format)) &&
            (!filter.Region.HasValue || manga.Region == MangaMapper.ToDomainRegion(filter.Region)) &&
            (!filter.ReleaseStatus.HasValue || manga.ReleaseStatus == MangaMapper.ToDomainReleaseStatus(filter.ReleaseStatus)) &&
            (!filter.PublishedDayOfWeek.HasValue || manga.PublishedDate.HasValue &&
                (EF.Functions.DateDiffDay(DateTime.SpecifyKind(new DateTime(1900, 1, 1), DateTimeKind.Utc), manga.PublishedDate.Value) + 1) % 7 == (int)filter.PublishedDayOfWeek.Value))
        {
            if (includePaging)
            {
                ApplyPaging((filter.PageNumber - 1) * filter.PageSize, filter.PageSize);
            }

            // Apply sorting based on filter
            switch (filter.SortOrder)
            {
                case MangaSortOrder.Oldest:
                    AddOrderBy(m => m.PublishedDate ?? DateTime.MinValue);
                    break;
                case MangaSortOrder.Latest:
                    AddOrderByDescending(m => m.PublishedDate ?? DateTime.MinValue);
                    break;
                default:
                    AddOrderByDescending(m => m.Id);
                    break;
            }

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
