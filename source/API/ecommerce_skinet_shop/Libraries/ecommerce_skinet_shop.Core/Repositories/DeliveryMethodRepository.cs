using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public class DeliveryMethodRepository : Repository<DeliveryMethod, int, OrderContext>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(OrderContext dbContext)
            : base(dbContext)
        {

        }
    }
}
