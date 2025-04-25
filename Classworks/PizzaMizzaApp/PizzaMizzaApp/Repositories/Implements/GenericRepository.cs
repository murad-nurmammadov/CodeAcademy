using Dapper;
using PizzaMizzaApp.Exceptions;
using PizzaMizzaApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace PizzaMizzaApp.Repositories.Implements;

internal class GenericRepository<T> : IRepository<T>
{
    private readonly string _connString = @"Server=.\SQLEXPRESS; 
                                            Database=PizzaMizza; 
                                            Trusted_Connection=True; 
                                            TrustServerCertificate=True;";
    
    private readonly string _tableName = typeof(T).Name + "s";
    private readonly List<string> _propertyNames = [];

    public GenericRepository()
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        _propertyNames = properties.Select(p => p.Name).ToList();
    }
    
    public int Add(T product)
    {
        using (SqlConnection db = new SqlConnection(_connString))
        {
            string str = string.Join(',', _propertyNames.Where(p => p != "Id").Select(p => $"@{p}"));
            string sql = $"INSERT INTO {_tableName} VALUES ({str})";
            int numRowsAffected = db.Execute(sql, product);

            if (numRowsAffected == 0)
                throw new ProductNotFoundException();

            return numRowsAffected;
        }
    }

    public int Update(T product)
    {
        using (SqlConnection db = new SqlConnection(_connString))
        {
            string str = string.Join(',', _propertyNames.Where(p => p != "Id").Select(p => $"{p}=@{p}"));

            string sql = $"UPDATE {_tableName} SET {str} WHERE Id = @Id";
            int numRowsAffected = db.Execute(sql, product);

            if (numRowsAffected == 0)
                throw new ProductNotFoundException();

            return numRowsAffected;
        }
    }

    public int Delete(int id)
    {
        using (SqlConnection db = new SqlConnection(_connString))
        {
            string sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            int numRowsAffected = db.Execute(sql, new { Id = id });

            if (numRowsAffected == 0)
                throw new ProductNotFoundException();

            return numRowsAffected;
        }
    }

    public T GetById(int id)
    {
        using (SqlConnection db = new SqlConnection(_connString))
        {
            string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            T product = db.QuerySingleOrDefault<T>(sql, new { Id = id });

            if (product is null)
                throw new ProductNotFoundException();

            return product;
        }
    }

    public List<T> GetAll()
    {
        using (SqlConnection db = new SqlConnection(_connString))
        {
            string sql = $"SELECT * FROM {_tableName}";
            return db.Query<T>(sql).ToList();
        }
    }
}
