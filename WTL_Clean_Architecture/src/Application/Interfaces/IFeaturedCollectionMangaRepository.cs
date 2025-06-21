using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionMangaRepository : IRepositoryBase<FeaturedCollectionManga, string>
    {
        Task<FeaturedCollectionManga?> GetFeaturedCollectionMangaById(string collectionId, string mangaId);
        Task<FeaturedCollectionManga> CreateFeaturedCollectionMangaAsync(CreateFeaturedCollectionMangaDto model);
        Task<FeaturedCollectionManga?> DeleteFeaturedCollectionMangaAsync(string collectionId, string mangaId);
    }
}
