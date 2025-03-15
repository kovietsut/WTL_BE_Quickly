using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionRepository : IRepositoryBase<FeaturedCollection, long>
    {
        Task<FeaturedCollection?> GetFeaturedCollectionById(long id);
        Task<List<FeaturedCollection>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<FeaturedCollection> CreateFeaturedCollectionAsync(CreateFeaturedCollectionDto model);
        Task<FeaturedCollection> UpdateFeaturedCollectionAsync(long featuredCollectionId, UpdateFeaturedCollectionDto model);
        Task<FeaturedCollection?> DeleteFeaturedCollectionAsync(long id);
    }
}
