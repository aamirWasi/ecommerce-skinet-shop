using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Entities.OrderAggregate
{
    public class OrderItem : IEntity<int>
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, int quantity, decimal price)
        {
            ItemOrdered = itemOrdered;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
