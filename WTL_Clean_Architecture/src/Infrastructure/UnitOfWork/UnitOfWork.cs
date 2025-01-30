using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context = context;

        public void Dispose() => _context.Dispose();

        public Task<int> CommitAsync() => _context.SaveChangesAsync();
    }
}
