using Application.Models;
using Domain.Entities;
using Domain.SpecificationModels;

namespace Application.Interfaces
{
    public interface IMangaRepository : IRepositoryBase<Manga, long>
    {
        Task<Manga?> GetMangaById(long id);
        Task<(List<Manga> Items, int TotalCount)> GetList(MangaFilterDto filter);
        Task<Manga> CreateMangaAsync(CreateMangaDto model);
        Task<Manga> UpdateMangaAsync(long mangaId, UpdateMangaDto model);
        Task<Manga?> DeleteMangaAsync(long id);
    }
}
