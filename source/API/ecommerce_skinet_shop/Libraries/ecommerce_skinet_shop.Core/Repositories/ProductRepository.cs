using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public interface IProductRepository : IRepository<Product, int, StoreContext>
    {

    }

    public interface IProductBrandRepository : IRepository<ProductBrand, int, StoreContext>
    {

    }

    public interface IProductTypeRepository : IRepository<ProductType, int, StoreContext>
    {

    }
    public class ProductRepository : Repository<Product, int, StoreContext>, IProductRepository
    {
        public ProductRepository(StoreContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ProductTypeRepository : Repository<ProductType, int, StoreContext>, IProductTypeRepository
    {
        public ProductTypeRepository(StoreContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ProductBrandRepository : Repository<ProductBrand, int, StoreContext>, IProductBrandRepository
    {
        public ProductBrandRepository(StoreContext dbContext)
            : base(dbContext)
        {

        }
    }
}
