using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Entities
{
    public class ProductType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
