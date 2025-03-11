using Application.Interfaces;
using Domain.Entities;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RepositoryQueryBase<T, K>
    where T : EntityBase<K>
    {

    }
    public class RepositoryQueryBase<T, K, TContext>(TContext dbContext)
    : RepositoryQueryBase<T, K>, IRepositoryQueryBase<T, K, TContext>
    where T : EntityBase<K>
    where TContext : DbContext
    {
        private readonly TContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Set<T>().CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync(predicate);
        }

        public IQueryable<T> FindAll(bool trackChanges = false) =>
            !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();

        public IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = FindAll(trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return items;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            !trackChanges
                ? _dbContext.Set<T>().Where(expression).AsNoTracking()
                : _dbContext.Set<T>().Where(expression);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = FindByCondition(expression, trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return items;
        }

        public async Task<T?> GetByIdAsync(K id) =>
            await FindByCondition(x => x.Id != null && x.Id.Equals(id))
                .FirstOrDefaultAsync();

        public async Task<T?> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties) =>
            await FindByCondition(x => x.Id != null && x.Id.Equals(id), trackChanges: false, includeProperties)
                .FirstOrDefaultAsync();

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Any(predicate);
        }

        public IQueryable<T> FindBySpecification(Specification<T, K>? specification, bool trackChanges = false)
        {
            var query = FindAll(trackChanges);
            return SpecificationQueryBuilder.GetQuery(query, specification);
        }

        public async Task<T?> GetBySpecificationAsync(Specification<T, K> specification, bool trackChanges = false)
        {
            return await FindBySpecification(specification, trackChanges).FirstOrDefaultAsync();
        }
    }

}
