using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
