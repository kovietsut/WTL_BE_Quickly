using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications
{
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(
            IQueryable<TEntity> query, Specification<TEntity, TKey>? specification)
            where TEntity : EntityBase<TKey>
        {
            var queryable = query;

            if (specification is not null)
            {
                if (specification.Criteria is not null)
                {
                    queryable = queryable.Where(specification.Criteria);
                }

                foreach (var include in specification.Includes)
                {
                    queryable = include(queryable);
                }

                foreach (var includeString in specification.IncludeStrings)
                {
                    queryable = queryable.Include(includeString);
                }

                if (specification.OrderByExpression is not null)
                {
                    queryable = queryable.OrderBy(specification.OrderByExpression);
                }

                if (specification.OrderByDescendingExpression is not null)
                {
                    queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
                }

                if (specification.IsSplitQuery)
                {
                    queryable = queryable.AsSplitQuery();
                }

                if (specification.Skip.HasValue)
                {
                    queryable = queryable.Skip(specification.Skip.Value);
                }

                if (specification.Take.HasValue)
                {
                    queryable = queryable.Take(specification.Take.Value);
                }
            }
            return queryable;
        }
    }

}
