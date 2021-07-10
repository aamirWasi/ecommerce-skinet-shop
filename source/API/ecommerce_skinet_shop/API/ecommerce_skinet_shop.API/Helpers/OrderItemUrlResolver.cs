using AutoMapper;
using ecommerce_skinet_shop.API.Dtos;
using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace ecommerce_skinet_shop.API.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.ItemOrdered.PictureUrl))
                return _configuration["ApiUrl"] + source.ItemOrdered.PictureUrl;
            return null;
        }
    }
}
