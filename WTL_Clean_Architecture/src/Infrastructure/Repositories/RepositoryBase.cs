using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TKey> : RepositoryQueryBase<TEntity, TKey> where TEntity : EntityBase<TKey> { }

    public class RepositoryBase<TEntity, TKey, TContext>(TContext dbContext, IUnitOfWork<TContext> unitOfWork) : RepositoryQueryBase<TEntity, TKey, TContext>(dbContext),
        IRepositoryBase<TEntity, TKey, TContext>
        where TEntity : EntityBase<TKey>
        where TContext : DbContext
    {
        private readonly TContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly IUnitOfWork<TContext> _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public Task<IDbContextTransaction> BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();

        public async Task EndTransactionAsync()
        {
            await SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public Task RollbackTransactionAsync() => _dbContext.Database.RollbackTransactionAsync();

        public void Create(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);

        public async Task<TKey> CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public IList<TKey> CreateList(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            return entities.Select(x => x.Id).ToList();
        }

        public async Task<IList<TKey>> CreateListAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities.Select(x => x.Id).ToList();
        }

        public void Update(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return;
            var exist = _dbContext.Set<TEntity>().Find(entity.Id);
            if (exist != null) _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return;

            var exist = _dbContext.Set<TEntity>().Find(entity.Id);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                await SaveChangesAsync();
            }
        }

        public void UpdateList(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public async Task UpdateListAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
            await SaveChangesAsync();
        }

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public void DeleteList(IEnumerable<TEntity> entities) => _dbContext.Set<TEntity>().RemoveRange(entities);

        public async Task DeleteListAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync() => await _unitOfWork.CommitAsync();
    }
}
