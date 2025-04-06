using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMangaInteractionRepository : IRepositoryBase<MangaInteraction, long>
    {
        Task<MangaInteraction> CreateMangaInteractionAsync(CreateMangaInteractionDto mangaInteractionDto);
        Task<MangaInteraction?> DeleteMangaInteractionAsync(long? mangaId, long? chapterId);
        Task<MangaInteraction?> GetMangaInteractionByUserAndContentAsync(long userId, long? mangaId, long? chapterId);
    }
} 