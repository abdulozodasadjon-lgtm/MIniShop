using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Dapper;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<int> AddProductAsync(Product product)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "insert into products (name, price, categoryid) values (@name, @price, @categoryid)";
        return await conn.ExecuteAsync(query, new { product.Name, product.Price, product.CategoryId });
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "delete from products where id = @id";
        return await conn.ExecuteAsync(query, new { id });
    }

    public async Task<int> UpdateProductAsync(Product product)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "udpate products set name = @name, price = @price, categoryid = @categoryid where id = @id";
        return await conn.ExecuteAsync(query, new { product.Name, product.Price, product.CategoryId, product.Id });
    }


    public async Task<List<Product_for_getting>> GetAllProductsAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select p.id, p.name, p.price, c.name as category from products p join categories c on c.id = p.categoryid";
        var products = await conn.QueryAsync<Product_for_getting>(query);
        return products.ToList();
    }

    public async Task<Product_for_getting> GetProductAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select p.id, p.name, p.price, c.name as category from products p join categories c on c.id = p.categoryid where p.id = @id";
        return await conn.QueryFirstAsync<Product_for_getting>(query, new { id });
    }

    public async Task<List<Product_for_getting>> GetProductsByCategoryAsync(int cid)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select p.id, p.name, p.price, c.name as category from products p join categories c on c.id = p.categoryid where p.categoryid = @cid";
        var products = await conn.QueryAsync<Product_for_getting>(query, new { cid });
        return products.ToList();
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select count(*) from products";
        return await conn.QuerySingleAsync<int>(query);
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int cid)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select count(*) from products where categoryid = @cid";
        return await conn.QuerySingleAsync<int>(query, new { cid });
    }

    public async Task<int> GetMinAmountOfProductsByCategoryAsync(int cid)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select c.name, min(p.price) from products where categoryid  group by gategoryid having count(*)";
        return await conn.QuerySingleAsync<int>(query, new { cid });
    }

}
