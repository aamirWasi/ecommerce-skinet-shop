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
        public ProductWithBrandsAndTypesSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductWithBrandsAndTypesSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
