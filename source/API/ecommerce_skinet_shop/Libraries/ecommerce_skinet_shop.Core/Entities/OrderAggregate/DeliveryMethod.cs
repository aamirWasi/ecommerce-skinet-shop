using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Entities.OrderAggregate
{
    public class DeliveryMethod : IEntity<int>
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Price { get; set; }
    }
}
