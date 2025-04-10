using Application.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IMangaInteractionRepository : IRepositoryBase<MangaInteraction, long>
    {
        Task<MangaInteraction> CreateMangaInteractionAsync(CreateMangaInteractionDto mangaInteractionDto);
        Task<MangaInteraction?> DeleteMangaInteractionAsync(long? mangaId, long? chapterId);
        Task<MangaInteraction?> GetMangaInteractionByUserAndContentAsync(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType);
        Task<IEnumerable<MangaInteraction>> GetMangaInteractionListAsync(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType, int? pageNumber, int? pageSize);
    }
} 