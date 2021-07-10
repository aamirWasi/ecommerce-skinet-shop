﻿using ecommerce_skinet_shop.Core.Contexts;
using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order, int, OrderContext>
    {

    }
}
