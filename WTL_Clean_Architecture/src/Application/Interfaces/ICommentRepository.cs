using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment, long>
    {
        Task<Comment> CreateCommentAsync(CreateCommentDto dto);
    }
} 