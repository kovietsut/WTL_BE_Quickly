using Domain.Entities;

namespace Domain.Specifications.Mangas
{
    public class GetMangaByIdSpecification : Specification<Manga, string>
    {
        public GetMangaByIdSpecification(string id) : base(manga => manga.Id == id)
        {
            AddInclude("MangaGenres.Genre");
            AddInclude(m => m.SubAuthorNavigation);
            AddInclude(m => m.ArtistNavigation);
            AddInclude(m => m.TranslatorNavigation);
            AddInclude(m => m.PublishorNavigation);
            IsSplitQuery = true;
        }
    }
}
