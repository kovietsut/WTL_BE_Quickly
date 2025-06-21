using Domain.Entities;

namespace Domain.Specifications.FeaturedCollectionPermissions
{
    public class GetFeaturedCollectionPermissionByIdSpecification : Specification<FeaturedCollectionPermission, string>
    {
        public GetFeaturedCollectionPermissionByIdSpecification(string collectionId, string userId) : base(x =>
            x.FeaturedCollectionId == collectionId &&
            x.UserId == userId)
        {
            AddInclude(x => x.FeaturedCollection);
            AddInclude(x => x.User);
        }
    }
}
