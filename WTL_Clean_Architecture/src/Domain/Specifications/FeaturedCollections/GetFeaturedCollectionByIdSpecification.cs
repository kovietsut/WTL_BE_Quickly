using Domain.Entities;

namespace Domain.Specifications.FeaturedCollections
{
    public class GetFeaturedCollectionByIdSpecification : Specification<FeaturedCollection, long>
    {
        public GetFeaturedCollectionByIdSpecification(long id) : base(collection => collection.Id == id)
        {

        }
    }
}
