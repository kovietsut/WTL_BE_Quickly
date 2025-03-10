using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IChapterRepository : IRepositoryBase<Chapter, long>
    {
        Task<Chapter?> GetChapterById(long id);
        Task<List<Chapter>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<Chapter> CreateChapterAsync(CreateChapterDto model);
        Task<Chapter> UpdateChapterAsync(long chapterId, UpdateChapterDto model);
        Task<Chapter?> DeleteChapterAsync(long id);
    }
}
