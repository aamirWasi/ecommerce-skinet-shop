using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using ecommerce_skinet_shop.Core.Repositories;
using ecommerce_skinet_shop.Core.Specifications;
using ecommerce_skinet_shop.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Core.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderUnitOfWork _orderUnitOfWork;
        private readonly IStoreUnitOfWork _storeUnitOfWork;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IOrderUnitOfWork orderUnitOfWork, IStoreUnitOfWork storeUnitOfWork,IBasketRepository basketRepository)
        {
            _orderUnitOfWork = orderUnitOfWork;
            _storeUnitOfWork = storeUnitOfWork;
            _basketRepository = basketRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail,int deliveryMethodId,string basketId,Address shippingAddress)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _storeUnitOfWork.ProductRepository.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, item.Quantity, item.Price);
                items.Add(orderItem);
            }

            var deliveryMethod = await _orderUnitOfWork.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId);

            var subTotal = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal);

            _orderUnitOfWork.OrderRepository.Add(order);

            var result = _orderUnitOfWork.Save();
            if (result <= 0) return null;

            await _basketRepository.DeleteBasket(basketId);

            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            return await _orderUnitOfWork.OrderRepository.GetEntitiesWithSpec(spec);
        }

        public async Task<Order> GetOrderbyIdAsync(int id,string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id,buyerEmail);
            return await _orderUnitOfWork.OrderRepository.GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _orderUnitOfWork.DeliveryMethodRepository.GetAsync();
        }
    }
}
