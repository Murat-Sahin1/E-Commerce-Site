using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoriesRepo;
        private readonly StoreContext _storeContext;
        
        public CategoriesController(IGenericRepository<Category> categoriesRepo,
        StoreContext storeContext){
            _categoriesRepo = categoriesRepo;
            _storeContext = storeContext;      
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var spec = new CategoriesSortedByNameSpecification();
            var categories = await _categoriesRepo.ListAsync(spec);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var spec = new CategoriesSortedByNameSpecification(id);
            return await _categoriesRepo.GetEntityWithSpec(spec);
        }

        [HttpPost("/api/[controller]/add")]
        public async Task<ActionResult<Category>> AddCategory(CategoryDto categoryDto){

            Category myCategory = new Category{
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                PictureUrl = categoryDto.PictureUrl
            };

           await _storeContext.Categories.AddAsync(myCategory);
           await _storeContext.SaveChangesAsync();
           return myCategory;
        }

        [HttpDelete("/api/[controller]/delete/{id}")]

        public async Task<ActionResult<Category>> DeleteCategory(int id){
            var spec = new CategoriesSortedByNameSpecification(id);
            var category = await _categoriesRepo.GetEntityWithSpec(spec);

            _storeContext.Categories.Remove(category);
            await _storeContext.SaveChangesAsync();

            return category;
        }

        [HttpPut("/api/[controller]/update/{id}")]

        public async Task<ActionResult<Category>> UpdateCategory(int id,
        CategoryDto categoryDto){
            var categoryToUpdate = await _categoriesRepo.GetByIdAsync(id);

            Category myCategory = new Category{
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                PictureUrl = categoryDto.PictureUrl
            };

            categoryToUpdate.Name = categoryDto.Name;
            categoryToUpdate.Description = categoryToUpdate.Description;
            categoryToUpdate.PictureUrl = categoryToUpdate.PictureUrl;

            _storeContext.Categories.Update(categoryToUpdate);
            await _storeContext.SaveChangesAsync();

            return await _storeContext.Categories.FindAsync(id);
        }
    }
}