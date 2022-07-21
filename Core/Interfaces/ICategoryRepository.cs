using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}