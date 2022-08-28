using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        //IQueryable<TEntity> inputQuery represents our DBset with the type of products
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, 
        ISpecification<TEntity> spec){
            //Because query is now a dbset, we can use dbset methods
            var query = inputQuery;

            if(spec.Criteria != null){ //our criteria was x => x.Id == id,
                //so this means rearrange the query, where our given Id matches one of the DBSet item
                //therefore query now includes only one item of the given type, which is product in this example.
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null){ 
                query = query.OrderBy(spec.OrderBy);
            }

            
            if(spec.OrderByDescending != null){ 
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            //.Include(p => p.ProductBrand).Include(p => p.ProductType)
            // After that, this method aggregate the include expressions we gave.
            //And it will take the list of includes from the given specification's Includes list, which is defined at BaseSpecification.
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}