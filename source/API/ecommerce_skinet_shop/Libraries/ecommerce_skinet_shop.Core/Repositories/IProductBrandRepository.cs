using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public interface IProductBrandRepository : IRepository<ProductBrand, int, StoreContext>
    {

    }
}
