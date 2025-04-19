using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface ICommentReactionRepository : IRepositoryBase<CommentReaction, long>
    {
        Task<(IEnumerable<CommentReaction> Items, int TotalCount)> GetListByCommentIdAsync(long commentId, int? pageNumber = null, int? pageSize = null);
        Task<CommentReaction?> GetByCommentAndUserAsync(long commentId, long userId);
        Task<CommentReaction> CreateAsync(long commentId, CommentReactionType reactionType, string? reason = null);
        Task<CommentReaction> UpdateAsync(long id, CommentReactionType reactionType, string? reason = null);
        Task<bool> DeleteAsync(long id);
    }
} 