namespace ecommerce_skinet_shop.Infrustructure
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
