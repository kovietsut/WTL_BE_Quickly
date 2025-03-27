using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public abstract class Specification<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
        public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ThenIncludes { get; } = new();
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }
        public bool IsSplitQuery { get; protected set; }
        public int? Skip { get; private set; }
        public int? Take { get; private set; }

        public Specification() {}

        public Specification(Expression<Func<TEntity, bool>>? criteria) => Criteria = criteria;

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddThenInclude<TPreviousProperty>(Expression<Func<TPreviousProperty, object>> thenIncludeExpression)
        {
            ThenIncludes.Add(query => 
            {
                if (query is IIncludableQueryable<TEntity, TPreviousProperty> includableQuery)
                {
                    return includableQuery.ThenInclude(thenIncludeExpression);
                }
                throw new InvalidOperationException($"Query must be an IIncludableQueryable<{typeof(TEntity).Name}, {typeof(TPreviousProperty).Name}> before calling ThenInclude");
            });
        }
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) => OrderByExpression = orderByExpression;
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) => OrderByDescendingExpression = orderByDescendingExpression;

        protected void ApplyPaging(int? skip, int? take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
