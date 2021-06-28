using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ecommerce_skinet_shop.Infrustructure
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }
        public IList<Expression<Func<TEntity, object>>> Includes { get; private set; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> Orderby { get; private set; }
        public Expression<Func<TEntity, object>> OrderbyDescending { get; private set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<TEntity,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderby(Expression<Func<TEntity,object>> orderbyExpression)
        {
            Orderby = orderbyExpression;
        }

        protected void AddOrderbyDescending(Expression<Func<TEntity, object>> orderbyDescendingExpression)
        {
            OrderbyDescending = orderbyDescendingExpression;
        }

    }
}
