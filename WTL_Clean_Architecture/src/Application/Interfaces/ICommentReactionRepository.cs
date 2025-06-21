using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface ICommentReactionRepository : IRepositoryBase<CommentReaction, string>
    {
        Task<(IEnumerable<CommentReaction> Items, int TotalCount)> GetListByCommentIdAsync(string commentId, int? pageNumber = null, int? pageSize = null);
        Task<CommentReaction?> GetByCommentAndUserAsync(string commentId, string userId);
        Task<CommentReaction> CreateAsync(string commentId, CommentReactionType reactionType, string? reason = null);
        Task<CommentReaction> UpdateAsync(string id, CommentReactionType reactionType, string? reason = null);
        Task<bool> DeleteAsync(string id);
    }
} 