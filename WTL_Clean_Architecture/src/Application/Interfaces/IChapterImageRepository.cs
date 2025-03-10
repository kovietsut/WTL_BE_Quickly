using Application.Models;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChapterImageRepository : IRepositoryBase<ChapterImage, long>
    {
        Task<ChapterImage?> GetChapterImageById(long id);
        Task<List<ChapterImage>> GetList(int? pageNumber, int? pageSize, string? searchText);
        Task<List<ChapterImage>> GetListByChapterId(long chapterId);
        Task<List<ChapterImage>> CreateListChapterImageAsync(long chapterId, List<ChapterImageDto>? chapterImages);
        Task<ChapterImage> UpdateChapterImageAsync(long chapterId, UpdateChapterDto model);
        Task<List<ChapterImage>> DeleteChapterImageListAsync(long id);
    }
}
