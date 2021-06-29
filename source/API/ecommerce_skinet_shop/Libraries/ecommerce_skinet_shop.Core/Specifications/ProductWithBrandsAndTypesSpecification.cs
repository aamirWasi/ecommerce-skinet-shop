using ecommerce_skinet_shop.Core.Entities;
using ecommerce_skinet_shop.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Core.Specifications
{
    public class ProductWithBrandsAndTypesSpecification:BaseSpecification<Product>
    {
        public ProductWithBrandsAndTypesSpecification(ProductSpecParams productSpec) : base(
            x=>
            (!productSpec.BrandId.HasValue || x.ProductBrandId==productSpec.BrandId) &&
            (!productSpec.TypeId.HasValue || x.ProductTypeId== productSpec.TypeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderby(x => x.Name);
            ApplyPaging(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);
            if (!string.IsNullOrWhiteSpace(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderby(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderbyDescending(p => p.Price);
                        break;
                    default:
                        AddOrderby(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithBrandsAndTypesSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
