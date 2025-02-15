using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGenreRepository: IRepositoryBase<Genere, long>
    {
        Task<Genere?> GetGenreById(long id);
        Task<List<Genere>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<Genere> CreateGenreAsync(CreateGenreDto model);
        Task<Genere> UpdateGenreAsync(long genreId, UpdateGenreDto model);
        Task<Genere?> DeleteGenreAsync(long id);
    }
}
