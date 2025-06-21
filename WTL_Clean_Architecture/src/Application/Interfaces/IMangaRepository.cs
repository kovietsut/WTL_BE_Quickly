using Application.Models;
using Domain.Entities;
using Domain.SpecificationModels;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IMangaRepository : IRepositoryBase<Manga, string>
    {
        Task<Manga?> GetMangaById(string id);
        Task<(List<Manga> Items, int TotalCount)> GetList(MangaFilterDto filter);
        Task<Manga> CreateMangaAsync(CreateMangaDto model);
        Task<Manga> UpdateMangaAsync(string mangaId, UpdateMangaDto model);
        Task<Manga?> DeleteMangaAsync(string id);
        Task<string> UploadCoverImageAsync(string mangaId, IFormFile coverImageFile);
    }
}
