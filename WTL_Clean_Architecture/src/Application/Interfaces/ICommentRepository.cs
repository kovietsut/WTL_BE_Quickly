using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment, string>
    {
        Task<(IEnumerable<object> Items, int TotalCount)> GetListAsync(string? mangaId, string? chapterId, string? parentCommentId, int pageNumber, int pageSize);
        Task<Comment> GetCommendByIdAsync(string id);
        Task<Comment> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<Comment> UpdateCommentAsync(string id, UpdateCommentDto updateCommentDto);
        Task<bool> DeleteCommentAsync(string id);
        Task<bool> DeleteChildCommentsAsync(string parentCommentId);
    }
} 