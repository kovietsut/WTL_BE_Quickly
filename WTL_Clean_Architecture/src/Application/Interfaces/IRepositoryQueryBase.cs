using Domain.Entities;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepositoryQueryBase<T, K> where T : EntityBase<K>
    {
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        IQueryable<T> FindAll(bool trackChanges = false);
        IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
            params Expression<Func<T, object>>[] includeProperties);

        Task<T?> GetByIdAsync(K id);
        Task<T?> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);
        bool Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBySpecification(Specification<T, K>? specification, bool trackChanges = false);
        Task<T?> GetBySpecificationAsync(Specification<T, K> specification, bool trackChanges = false);
    }

    public interface IRepositoryQueryBase<T, K, TContext>
        : IRepositoryQueryBase<T, K>
        where T : EntityBase<K>
        where TContext : DbContext
    { }
}
