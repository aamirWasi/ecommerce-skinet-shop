using ecommerce_skinet_shop.Core.Entities;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> DeleteBasket(string basketId);
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    }
}