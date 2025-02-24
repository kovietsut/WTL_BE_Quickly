using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMangaRepository : IRepositoryBase<Manga, long>
    {
        Task<Manga?> GetMangaById(long id);
        Task<List<Manga>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<Manga> CreateMangaAsync(CreateMangaDto model);
        Task<Manga> UpdateMangaAsync(long genreId, UpdateMangaDto model);
        Task<Manga?> DeleteMangaAsync(long id);
    }
}
