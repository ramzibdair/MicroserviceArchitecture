
using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Order.Infrastructure.Specifications
{
    public abstract class Specification<TEntity> where TEntity : EntityBase
    {
        protected Specification(Predicate<TEntity> criteria) => Criteria = criteria;

        public Expression<Func<TEntity,bool>>? Criteria { get;  }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> incudeExpression)
        {
            IncludeExpressions.Add(incudeExpression);
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderByExpression = orderByExpression;
        }

        protected void AddOrderByDesending(Expression<Func<TEntity, object>> orderByDesendingExpression)
        {
            OrderByDescendingExpression = orderByDesendingExpression;
        }
    }
}
