using Application.Models;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChapterImageRepository : IRepositoryBase<ChapterImage, string>
    {
        Task<ChapterImage?> GetChapterImageById(string id);
        Task<List<ChapterImage>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<List<ChapterImage>> GetListByChapterId(string chapterId);
        Task<List<ChapterImage>> CreateListChapterImageAsync(string chapterId, List<ChapterImageDto>? chapterImages);
        Task<ChapterImage> UpdateChapterImageAsync(string chapterId, UpdateChapterDto model);
        Task<List<ChapterImage>> DeleteChapterImageListAsync(string id);
    }
}
