using Application.Models;
using Domain.Entities;
using Domain.SpecificationModels;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IMangaRepository : IRepositoryBase<Manga, long>
    {
        Task<Manga?> GetMangaById(long id);
        Task<(List<Manga> Items, int TotalCount)> GetList(MangaFilterDto filter);
        Task<Manga> CreateMangaAsync(CreateMangaDto model);
        Task<Manga> UpdateMangaAsync(long mangaId, UpdateMangaDto model);
        Task<Manga?> DeleteMangaAsync(long id);
        Task<string> UploadCoverImageAsync(long mangaId, IFormFile coverImageFile);
    }
}
