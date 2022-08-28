using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class CategoriesSortedByNameSpecification : BaseSpecification<Category>
    {
        public CategoriesSortedByNameSpecification()
        {
            AddOrderBy(c => c.Name);
        }

        public CategoriesSortedByNameSpecification(int id) 
        : base(x => x.Id == id)
        {
            AddOrderBy(c => c.Name);
        }
    }
}