using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionPermissionRepository : IRepositoryBase<FeaturedCollectionPermission, long>
    {
        Task<FeaturedCollectionPermission?> GetFeaturedCollectionPermissionById(long collectionId, long permissionId);
        Task<List<long>> CreateListFeaturedCollectionPermissionAsync(CreateFeaturedCollectionPermissionDto model);
        Task<bool> DeleteListFeaturedCollectionPermissionAsync(long collectionId, List<long> userIds);
    }
}
