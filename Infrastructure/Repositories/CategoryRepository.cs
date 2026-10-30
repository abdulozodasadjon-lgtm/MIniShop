using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Dapper;


namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public async Task<int> AddCategoryAsync(Category category)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "insert into categories (name) values (@name)";
        return await conn.ExecuteAsync(query, new { category.Name });
    }
    
    

    public async Task<int> DeleteCategoryAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "delete from categories where id = @id";
        return await conn.ExecuteAsync(query, new { id });
    }

    public async Task<int> UpdateCategoryAsync(Category category)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "udpate categories set name = @name where id = @id";
        return await conn.ExecuteAsync(query, new { category.Name, category.Id });
    }


    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select * from categories";
        var categories = await conn.QueryAsync<Category>(query);
        return categories.ToList();
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select * from categories where id = @id";
        return await conn.QuerySingleAsync<Category>(query, new { id });
    }

    public async Task<int> GetAmountOfCategoriesAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select count(*) from categories";
        return await conn.QuerySingleAsync<int>(query);
    }

    

}
