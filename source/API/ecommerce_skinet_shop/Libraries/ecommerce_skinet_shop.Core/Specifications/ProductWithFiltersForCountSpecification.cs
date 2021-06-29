using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;

namespace ecommerce_skinet_shop.Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpec) : base(
            x =>
            (string.IsNullOrWhiteSpace(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
            (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) &&
            (!productSpec.TypeId.HasValue || x.ProductTypeId == productSpec.TypeId)
            )
        {
        }
    }
}
