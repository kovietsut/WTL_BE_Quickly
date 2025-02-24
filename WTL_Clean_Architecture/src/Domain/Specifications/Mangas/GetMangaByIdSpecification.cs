using Domain.Entities;

namespace Domain.Specifications.Mangas
{
    public class GetMangaByIdSpecification : Specification<Manga, long>
    {
        public GetMangaByIdSpecification(long id) : base(manga => manga.Id == id)
        {

        }
    }
}
