using AutoMapper;
using ecommerce_skinet_shop.API.Dtos;
using ecommerce_skinet_shop.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace ecommerce_skinet_shop.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl))
                return _configuration["ApiUrl"] + source.PictureUrl;
            return null;
        }
    }
}
