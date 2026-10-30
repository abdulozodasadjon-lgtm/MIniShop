using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<int> AddCategoryAsync(Category category);
    Task<int> UpdateCategoryAsync(Category category);
    Task<int> DeleteCategoryAsync(int id);
    Task<Category> GetCategoryAsync(int id);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}
