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
    public class OrderUnitOfWork : UnitOfWork, IOrderUnitOfWork
    {
        public IOrderRepository OrderRepository { get; set; }
        public IOrderItemRepository OrderItemRepository { get; set; }
        public IDeliveryMethodRepository DeliveryMethodRepository { get; set; }
        public OrderUnitOfWork(OrderContext context,
            IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IDeliveryMethodRepository deliveryMethodRepository
            )
            : base(context)
        {
            OrderRepository = orderRepository;
            DeliveryMethodRepository = deliveryMethodRepository;
            OrderItemRepository = orderItemRepository;
        }
    }
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
