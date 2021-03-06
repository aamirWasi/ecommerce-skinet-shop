using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public class ProductRepository : Repository<Product, int, StoreContext>, IProductRepository
    {
        public ProductRepository(StoreContext dbContext)
            : base(dbContext)
        {

        }
    }
}
