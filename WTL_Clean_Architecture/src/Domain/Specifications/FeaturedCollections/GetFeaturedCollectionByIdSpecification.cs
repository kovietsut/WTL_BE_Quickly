using Domain.Entities;

namespace Domain.Specifications.FeaturedCollections
{
    public class GetFeaturedCollectionByIdSpecification : Specification<FeaturedCollection, string>
    {
        public GetFeaturedCollectionByIdSpecification(string id) : base(collection => collection.Id == id)
        {

        }
    }
}
