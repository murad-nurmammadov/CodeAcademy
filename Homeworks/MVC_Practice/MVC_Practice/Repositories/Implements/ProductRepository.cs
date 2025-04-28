using Dapper;
using Microsoft.Data.SqlClient;
using MVC_Practice.Exceptions;
using MVC_Practice.Models;

namespace MVC_Practice.Repositories.Implements;

public class ProductRepository : GenericRepository<Product>
{
    public override async Task<Product> GetByIdAsync(int id)
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = """
                SELECT *
                FROM Products AS p
                JOIN Categories AS c
                ON p.CategoryId = c.Id
                WHERE p.Id = @Id
                """;

            var products = await db.QueryAsync<Product, Category, Product>(
                sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                new { Id = id },
                splitOn: "Id"
            );

            var product = products.FirstOrDefault();
            return product ?? throw new ItemNotFoundException<Product>();
        }
    }

    public override async Task<List<Product>> GetAllAsync()
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = """
                SELECT *
                FROM Products AS p
                JOIN Categories AS c
                ON p.CategoryId = c.Id
                """;

            var products = await db.QueryAsync<Product, Category, Product>(
                sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                }
            );

            return products.ToList();
        }
    }
}
