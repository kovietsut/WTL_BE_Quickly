using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionPermissionRepository : IRepositoryBase<FeaturedCollectionPermission, string>
    {
        Task<FeaturedCollectionPermission?> GetFeaturedCollectionPermissionById(string collectionId, string permissionId);
        Task<List<string>> CreateListFeaturedCollectionPermissionAsync(CreateFeaturedCollectionPermissionDto model);
        Task<bool> DeleteListFeaturedCollectionPermissionAsync(string collectionId, List<string> userIds);
    }
}
