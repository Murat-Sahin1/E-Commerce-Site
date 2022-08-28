using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort)){
                switch(sort){
                case("priceAsc"): AddOrderBy(x => x.Price); break;
                case("priceDesc"): AddOrderByDescending(x => x.Price); break;
                default: AddOrderBy(n => n.Name); break;
                }
            }

            
        }

        //because we got an ID, it's going to hit this constructor
        public ProductsWithTypesAndBrandsSpecification(int id) 
        : base(x => x.Id == id) //we also going to create a BaseSpecification instance
                                //because we use base with a CRITERIA inside of it.
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}