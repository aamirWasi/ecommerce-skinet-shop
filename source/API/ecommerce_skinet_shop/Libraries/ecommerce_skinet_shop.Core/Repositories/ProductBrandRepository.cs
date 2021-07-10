using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public class ProductBrandRepository : Repository<ProductBrand, int, StoreContext>, IProductBrandRepository
    {
        public ProductBrandRepository(StoreContext dbContext)
            : base(dbContext)
        {

        }
    }
}
