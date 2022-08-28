using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        //Inside the BaseSpecification, we call this constructor and 
        //we set the criteria here to whatever that expression we gave.
        // which is (x => x.Id == id), which means give me the product that matches the given id.
        //and also include productBrand and productType
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get; }

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>(); //init

        public Expression<Func<T, object>> OrderBy { get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}
        //This method adds the given include expression via our specification, into a list of 
        //Includes defined above. Which we are going to use later for aggregating our query.
        protected void AddInclude(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression){
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression){
            OrderByDescending = orderByDescExpression;
        }
    }
}