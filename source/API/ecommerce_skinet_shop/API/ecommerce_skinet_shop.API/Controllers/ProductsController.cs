using AutoMapper;
using ecommerce_skinet_shop.API.Dtos;
using ecommerce_skinet_shop.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IStoreUnitOfWork _storeUnitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IStoreUnitOfWork storeUnitOfWork,IMapper mapper)
        {
            _storeUnitOfWork = storeUnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _storeUnitOfWork.ProductRepository.GetAsync();
            return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _storeUnitOfWork.ProductRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductType(int id)
        {
            var types = await _storeUnitOfWork.ProductTypeRepository.GetAsync();
            return Ok(_mapper.Map<IReadOnlyList<ProductTypeDto>>(types));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrand(int id)
        {
            var brands = await _storeUnitOfWork.ProductBrandRepository.GetAsync();
            return Ok(_mapper.Map<IReadOnlyList<ProductBrandDto>>(brands));
        }
    }
}
