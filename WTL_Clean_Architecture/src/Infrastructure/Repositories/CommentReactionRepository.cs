using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Persistence;
using Domain.Specifications.CommentReactions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentReactionRepository : RepositoryBase<CommentReaction, string, MyDbContext>, ICommentReactionRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentReactionRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(IEnumerable<CommentReaction> Items, int TotalCount)> GetListByCommentIdAsync(string commentId, int? pageNumber = null, int? pageSize = null)
        {
            // Get reactions with pagination
            var specification = new GetCommentReactionsByCommentIdSpecification(commentId, pageNumber, pageSize);
            var query = FindBySpecification(specification);
            var reactions = await query.ToListAsync();

            // Get total count with the same filters but without paging
            var countSpecification = new GetCommentReactionsByCommentIdSpecification(commentId);
            var countQuery = FindBySpecification(countSpecification);
            var totalCount = await countQuery.CountAsync();

            return (reactions, totalCount);
        }

        public async Task<CommentReaction?> GetByCommentAndUserAsync(string commentId, string userId)
        {
            var specification = new GetCommentReactionByCommentAndUserSpecification(commentId, userId);
            return await GetBySpecificationAsync(specification);
        }

        public async Task<CommentReaction> CreateAsync(string commentId, CommentReactionType reactionType, string? reason = null)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value ?? "0";
            
            var reaction = new CommentReaction
            {
                Id = Guid.NewGuid().ToString(),
                CommentId = commentId,
                UserId = userId,
                ReactionType = reactionType,
                Reason = reason,
                CreatedAt = DateTime.UtcNow
            };

            await CreateAsync(reaction);
            return reaction;
        }

        public async Task<CommentReaction> UpdateAsync(string id, CommentReactionType reactionType, string? reason = null)
        {
            var reaction = await GetByIdAsync(id);
            if (reaction == null)
            {
                throw new ArgumentNullException(nameof(reaction), "Comment reaction not found");
            }

            reaction.ReactionType = reactionType;
            reaction.Reason = reason;

            await UpdateAsync(reaction);
            return reaction;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var reaction = await GetByIdAsync(id);
            if (reaction == null)
            {
                return false;
            }

            await DeleteAsync(reaction);
            return true;
        }
    }
} 