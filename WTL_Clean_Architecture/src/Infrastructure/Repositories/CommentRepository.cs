using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications.Comments;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentRepository : RepositoryBase<Comment, long, MyDbContext>, ICommentRepository
    {
        public CommentRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork) 
            : base(dbContext, unitOfWork)
        {
        }

        public async Task<Comment> CreateCommentAsync(CreateCommentDto model)
        {
            var comment = new Comment
            {
                MangaId = model.MangaId,
                UserId = model.UserId,
                ParentCommentId = model.ParentCommentId,
                Content = model.Content,
                IsSpoiler = model.IsSpoiler,
                ChapterId = model.ChapterId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await CreateAsync(comment);
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(long id)
        {
            var comment = await GetByIdAsync(id);
            if (comment == null)
            {
                return false;
            }

            comment.IsDeleted = true;
            comment.UpdatedAt = DateTimeOffset.UtcNow;
            
            await UpdateAsync(comment);
            return true;
        }

        public async Task<bool> DeleteChildCommentsAsync(long parentCommentId)
        {
            // Get all child comments using the specification
            var specification = new GetChildCommentsSpecification(parentCommentId);
            var childCommentsQuery = FindBySpecification(specification);
            var childComments = await childCommentsQuery.ToListAsync();

            if (!childComments.Any())
            {
                return true; // No child comments to delete
            }

            // Mark all child comments as deleted
            foreach (var childComment in childComments)
            {
                childComment.IsDeleted = true;
                childComment.UpdatedAt = DateTimeOffset.UtcNow;
                await UpdateAsync(childComment);
            }

            return true;
        }

        public async Task<Comment?> GetByIdAsync(long id)
        {
            var specification = new GetCommentByIdSpecification(id);
            return await GetBySpecificationAsync(specification);
        }

        public async Task<(IEnumerable<object> Items, int TotalCount)> GetListAsync(long? mangaId, long? chapterId, long? parentCommentId, int pageNumber, int pageSize)
        {
            // Get comments with pagination
            var specification = new GetListCommentsSpecification(mangaId, chapterId, parentCommentId, pageNumber, pageSize);
            var query = FindBySpecification(specification);
            var comments = await query.ToListAsync();
            
            // Transform comments to DTOs
            var listData = comments.Select(x => new
            {
                x.Id,
                x.MangaId,
                x.ChapterId,
                x.ParentCommentId,
                x.Content,
                x.IsSpoiler,
                x.UserId,
                x.CreatedAt,
                x.UpdatedAt
            });

            // Get total count with the same filters but without paging
            var countSpecification = new GetListCommentsSpecification(mangaId, chapterId, parentCommentId, pageNumber, pageSize, includePaging: false);
            var countQuery = FindBySpecification(countSpecification);
            var totalCount = await countQuery.CountAsync();
            
            return (listData, totalCount);
        }

        public async Task<Comment> UpdateCommentAsync(long id, UpdateCommentDto updateCommentDto)
        {
            var comment = await GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(id), "Comment not found");
            
            // Keep old content if new content is null
            if (updateCommentDto.Content != null)
            {
                comment.Content = updateCommentDto.Content;
            }
            comment.IsSpoiler = updateCommentDto.IsSpoiler;
            comment.UpdatedAt = DateTimeOffset.UtcNow;

            await UpdateAsync(comment);
            return comment;
        }

        // Add any specific comment repository methods here
    }
} 