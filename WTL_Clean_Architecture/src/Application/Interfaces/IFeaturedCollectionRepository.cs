using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionRepository : IRepositoryBase<FeaturedCollection, string>
    {
        Task<FeaturedCollection?> GetFeaturedCollectionById(string id);
        Task<List<FeaturedCollection>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<FeaturedCollection> CreateFeaturedCollectionAsync(CreateFeaturedCollectionDto model);
        Task<FeaturedCollection> UpdateFeaturedCollectionAsync(string featuredCollectionId, UpdateFeaturedCollectionDto model);
        Task<FeaturedCollection> DeleteFeaturedCollectionAsync(string id);
    }
}
