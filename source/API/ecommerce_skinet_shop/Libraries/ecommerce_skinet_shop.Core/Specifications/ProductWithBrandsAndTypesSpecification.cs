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
        public ProductWithBrandsAndTypesSpecification(string sort, int? brandId, int? typeId):base(
            x=>
            (!brandId.HasValue || x.ProductBrandId==brandId) &&
            (!typeId.HasValue || x.ProductTypeId==typeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderby(x => x.Name);
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
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
