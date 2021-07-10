using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public class OrderItemRepository : Repository<OrderItem, int, OrderContext>, IOrderItemRepository
    {
        public OrderItemRepository(OrderContext dbContext)
            : base(dbContext)
        {

        }
    }
}
