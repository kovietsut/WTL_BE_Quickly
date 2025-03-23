using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFeaturedCollectionMangaRepository : IRepositoryBase<FeaturedCollectionManga, long>
    {
        Task<FeaturedCollectionManga?> GetFeaturedCollectionMangaById(long collectionId, long mangaId);
        Task<FeaturedCollectionManga> CreateFeaturedCollectionMangaAsync(CreateFeaturedCollectionMangaDto model);
        Task<FeaturedCollectionManga?> DeleteFeaturedCollectionMangaAsync(long collectionId, long mangaId);
    }
}
