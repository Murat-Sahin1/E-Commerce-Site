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
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
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