using Domain.Entities;

namespace Domain.Specifications.FeaturedCollectionMangas
{
    public class GetFeaturedCollectionMangaByIdSpecification : Specification<FeaturedCollectionManga, long>
    {
        public GetFeaturedCollectionMangaByIdSpecification(long collectionId, long mangaId) : base(x => 
        x.IsDeleted == false &&
        x.FeaturedCollectionId == collectionId && 
        x.MangaId == mangaId
        )
        {

        }
    }
}
