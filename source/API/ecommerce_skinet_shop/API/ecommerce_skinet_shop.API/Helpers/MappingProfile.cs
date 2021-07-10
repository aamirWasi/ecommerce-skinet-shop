﻿using AutoMapper;
using ecommerce_skinet_shop.API.Dtos;
using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Core.Entities.OrderAggregate;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d=>d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.ShortName))
                .ForMember(d=>d.ShippingPrice,o=>o.MapFrom(s=>s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
