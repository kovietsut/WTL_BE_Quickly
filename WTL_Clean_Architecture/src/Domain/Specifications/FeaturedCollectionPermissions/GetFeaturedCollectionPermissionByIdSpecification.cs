using Domain.Entities;

namespace Domain.Specifications.FeaturedCollectionPermissions
{
    public class GetFeaturedCollectionPermissionByIdSpecification : Specification<FeaturedCollectionPermission, long>
    {
        public GetFeaturedCollectionPermissionByIdSpecification(long collectionId, long userId) : base(x =>
        x.IsDeleted == false &&
        x.FeaturedCollectionId == collectionId &&
        x.UserId == userId
        )
        { }
    }
}
