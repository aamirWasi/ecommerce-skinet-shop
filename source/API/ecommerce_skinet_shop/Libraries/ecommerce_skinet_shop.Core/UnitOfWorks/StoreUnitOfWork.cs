using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Repositories;
using ecommerce_skinet_shop.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Core.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
        public IProductBrandRepository ProductBrandRepository { get; set; }
        public IProductTypeRepository ProductTypeRepository { get; set; }
        public StoreUnitOfWork(StoreContext context,
            IProductRepository productRepositroy, IProductBrandRepository productBrandRepository, IProductTypeRepository productTypeRepository
            )
            : base(context)
        {
            ProductRepository = productRepositroy;
            ProductTypeRepository = productTypeRepository;
            ProductBrandRepository = productBrandRepository;
        }
    }
}
