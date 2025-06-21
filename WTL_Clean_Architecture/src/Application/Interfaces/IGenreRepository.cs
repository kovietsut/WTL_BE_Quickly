using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGenreRepository: IRepositoryBase<Genere, string>
    {
        Task<Genere?> GetGenreById(string id);
        Task<List<Genere>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<Genere> CreateGenreAsync(CreateGenreDto model);
        Task<Genere> UpdateGenreAsync(string genreId, UpdateGenreDto model);
        Task<Genere?> DeleteGenreAsync(string id);
    }
}
