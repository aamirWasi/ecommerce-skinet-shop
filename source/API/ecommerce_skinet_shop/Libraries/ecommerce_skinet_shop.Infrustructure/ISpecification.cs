using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ecommerce_skinet_shop.Infrustructure
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity,bool>> Criteria { get; }
        IList<Expression<Func<TEntity,object>>> Includes { get; }
        Expression<Func<TEntity,object>> Orderby { get; }
        Expression<Func<TEntity,object>> OrderbyDescending { get; }
    }
}
