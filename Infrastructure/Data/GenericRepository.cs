using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

       
        public async Task<IReadOnlyList<T>> ListAllAsync() //List without a spec object
        {
            return await _context.Set<T>().ToListAsync();
        }

        //We passed a spec, which contains a criteria statement that describes what we want to get with the id
        //And also our include expressions
         public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            //Inside the generic repo, we're going to apply the specification
            return await ApplySpecification(spec).FirstOrDefaultAsync();
            //After we got the queryable object, we query the database with FirstOrDefaultAsync();
            //and return the data from the database
        }

        //ApplySpecification will return an IQueryable object with the given type, and will take a spec object as a parameter.
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            //SpecificationEvaluator<T>.GetQuery will return an IQueryable.
            //what we're doing is we're passing the DB set, which is going to be the product DB set,
            //and we also passing in the specification to our specificationEvaluator
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }


        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        /*
         public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        */

        public T Delete(T entity)
        {
            //T productToDelete = await _context.Set<T>().FindAsync(id);
           
            throw new NotImplementedException();
        }

        public void Change(T dbEntity, T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}