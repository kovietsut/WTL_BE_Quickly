using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public abstract class Specification<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new();
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }
        public bool IsSplitQuery { get; protected set; }
        public int? Skip { get; private set; }
        public int? Take { get; private set; }

        public Specification() { }

        public Specification(Expression<Func<TEntity, bool>>? criteria) => Criteria = criteria;

        protected void AddInclude<TProperty>(Expression<Func<TEntity, TProperty>> includeExpression)
        {
            Includes.Add(query => query.Include(includeExpression));
        }

        protected void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
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
