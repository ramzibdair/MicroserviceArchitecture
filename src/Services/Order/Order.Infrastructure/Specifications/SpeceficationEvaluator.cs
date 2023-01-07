using Microsoft.EntityFrameworkCore;
using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Specifications
{
    internal static class SpeceficationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQueryable, Specification<TEntity> specification) where TEntity : EntityBase
        {
            IQueryable<TEntity> qeryable = inputQueryable;
            if(specification.Criteria is not null)
            {
                qeryable = qeryable.Where(specification.Criteria);
            }

            qeryable = specification.IncludeExpressions.Aggregate(qeryable,
                (current, includeExpression) =>
                    current.Include(includeExpression));
            

            if(specification.OrderByExpression is not null)
            {
                qeryable.OrderBy(specification.OrderByExpression);
            }
            else if(specification.OrderByDescendingExpression is not null)
            {
                qeryable.OrderByDescending(specification.OrderByDescendingExpression);
            }
            return qeryable;
        }
    }
}
