using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<int> AddProductAsync(Product product);
    Task<int> UpdateProductAsync(Product product);
    Task<int> DeleteProductAsync(int id);
    Task<Product_for_getting> GetProductAsync(int id);
    Task<List<Product_for_getting>> GetAllProductsAsync();
    Task<List<Product_for_getting>> GetProductsByCategoryAsync(int cid);
    Task<int> GetAmountOfProductsAsync();
}
