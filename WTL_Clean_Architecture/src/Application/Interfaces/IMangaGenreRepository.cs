using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMangaGenreRepository
    {
        Task CreateMangaGenresAsync(string mangaId, List<string> genreIds);
        Task DeleteMangaGenresAsync(string mangaId);
    }
} 