using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IChapterRepository : IRepositoryBase<Chapter, string>
    {
        Task<Chapter?> GetChapterById(string id);
        Task<List<Chapter>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<Chapter> CreateChapterAsync(CreateChapterDto model);
        Task<Chapter> UpdateChapterAsync(string chapterId, UpdateChapterDto model);
        Task<Chapter?> DeleteChapterAsync(string id);
    }
}
