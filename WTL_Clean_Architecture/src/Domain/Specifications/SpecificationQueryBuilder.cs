using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications
{
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(
                IQueryable<TEntity> query,
                Specification<TEntity, TKey> specification
            ) where TEntity : EntityBase<TKey>
        {
            var queryable = query;
            if (specification is not null)
            {
                if (specification.Criteria is not null)
                {
                    queryable = queryable.Where(specification.Criteria);
                }

                if (specification.IncludeExpressions is not null)
                {
                    queryable = specification.IncludeExpressions.Aggregate(queryable, (current, include) => current.Include(include));
                }

                if (specification.OrderByExpression is not null)
                {
                    queryable = queryable.OrderBy(specification.OrderByExpression);
                }

                if (specification.OrderByDescendingExpression is not null)
                {
                    queryable = queryable.OrderBy(specification.OrderByDescendingExpression);
                }

                if (specification.IsSplitQuery)
                {
                    queryable = queryable.AsSplitQuery();
                }
            }

            return queryable;
        }
    }
}
