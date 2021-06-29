using System.Linq;

namespace ecommerce_skinet_shop.Infrustructure
{
    public interface ISpecificationEvalator<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec);
    }
}