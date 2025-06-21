using Domain.Entities;

namespace Domain.Specifications.MangaGenres
{
    public class GetMangaGenresByMangaIdSpecification : Specification<MangaGenre, string>
    {
        public GetMangaGenresByMangaIdSpecification(string mangaId) : base(x => x.MangaId == mangaId)
        {
        }
    }
} 