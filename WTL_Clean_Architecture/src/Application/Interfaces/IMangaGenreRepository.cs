using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMangaGenreRepository
    {
        Task CreateMangaGenresAsync(long mangaId, List<long> genreIds);
        Task DeleteMangaGenresAsync(long mangaId);
    }
} 