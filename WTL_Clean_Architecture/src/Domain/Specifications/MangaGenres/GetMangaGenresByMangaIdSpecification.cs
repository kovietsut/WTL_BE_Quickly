using Domain.Entities;

namespace Domain.Specifications.MangaGenres
{
    public class GetMangaGenresByMangaIdSpecification : Specification<MangaGenre, long>
    {
        public GetMangaGenresByMangaIdSpecification(long mangaId) : 
            base(mg => mg.MangaId == mangaId && !mg.IsDeleted)
        {
        }
    }
} 