using ecommerce_skinet_shop.Core.Repositories;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        IProductBrandRepository ProductBrandRepository { get; set; }
        IProductTypeRepository ProductTypeRepository { get; set; }
    }
}
