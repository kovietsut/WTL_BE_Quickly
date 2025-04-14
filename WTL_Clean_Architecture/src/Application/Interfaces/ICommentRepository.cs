using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment, long>
    {
        Task<(IEnumerable<object> Items, int TotalCount)> GetListAsync(long? mangaId, long? chapterId, long? parentCommentId, int pageNumber, int pageSize);
        Task<Comment> GetByIdAsync(long id);
        Task<Comment> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<Comment> UpdateCommentAsync(long id, UpdateCommentDto updateCommentDto);
        Task<bool> DeleteCommentAsync(long id);
    }
} 