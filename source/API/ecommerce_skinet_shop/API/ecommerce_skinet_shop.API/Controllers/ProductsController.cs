using Autofac;
using AutoMapper;
using ecommerce_skinet_shop.API.Dtos;
using ecommerce_skinet_shop.Core.Specifications;
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
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var spec = Startup.AutofacContainer.Resolve<ProductWithBrandsAndTypesSpecification>();//new ProductWithBrandsAndTypesSpecification();
            var products = await _storeUnitOfWork.ProductRepository.GetEntitiesWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductWithBrandsAndTypesSpecification(id);
            var product = await _storeUnitOfWork.ProductRepository.GetEntityWithSpec(spec);
            if (product == null)
                return NotFound();
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
