using ecommerce_skinet_shop.MembershipModule.Entities;

namespace ecommerce_skinet_shop.MembershipModule.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}