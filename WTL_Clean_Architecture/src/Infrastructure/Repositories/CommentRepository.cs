using Application.Features.Comments.Commands.Create;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;

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

        // Add any specific comment repository methods here
    }
} 