using Application.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IMangaInteractionRepository : IRepositoryBase<MangaInteraction, string>
    {
        Task<MangaInteraction> CreateMangaInteractionAsync(CreateMangaInteractionDto mangaInteractionDto);
        Task<MangaInteraction?> DeleteMangaInteractionAsync(string? mangaId, string? chapterId);
        Task<MangaInteraction?> GetMangaInteractionByUserAndContentAsync(string userId, string? mangaId, string? chapterId, MangaInteractionType? interactionType);
        Task<IEnumerable<MangaInteraction>> GetMangaInteractionListAsync(string userId, string? mangaId, string? chapterId, MangaInteractionType? interactionType, int? pageNumber, int? pageSize);
    }
} 