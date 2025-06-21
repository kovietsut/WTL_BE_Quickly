using Domain.Entities;

namespace Domain.Specifications.FeaturedCollectionMangas
{
    public class GetFeaturedCollectionMangaByIdSpecification : Specification<FeaturedCollectionManga, string>
    {
        public GetFeaturedCollectionMangaByIdSpecification(string collectionId, string mangaId) : base(x =>
            x.FeaturedCollectionId == collectionId &&
            x.MangaId == mangaId)
        {

        }
    }
}
