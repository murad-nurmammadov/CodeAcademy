using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using MVC_Practice.Exceptions;
using MVC_Practice.Repositories.Interfaces;

namespace MVC_Practice.Repositories.Implements;

public class GenericRepository<T> : IRepository<T>
{
    protected readonly string _connString = @"
        Server=.\SQLEXPRESS;
        Database=MVC_Practice_1;
        Trusted_Connection=True;
        TrustServerCertificate=True;
        ";
    protected readonly string _tableName;
    protected readonly List<string> _propertyNames;


    public GenericRepository()
    {
        _tableName = typeof(T).Name + "s";
        PropertyInfo[] properties = typeof(T).GetProperties();
        _propertyNames = properties.Select(p => p.Name).ToList();

        Console.WriteLine("Monitor:");
        Console.WriteLine(_tableName);
        _propertyNames.ForEach(name => Console.WriteLine(name));
    }

    public GenericRepository(string tableName) : this()
    {
        _tableName = tableName;
    }


    public async Task<int> AddAsync(T entity)
    {
        using (SqlConnection db = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id")
                                                        .Select(name => $"@{name}"));
            string sql = $"INSERT INTO {_tableName} VALUES ({_})";
            return await db.ExecuteAsync(sql, entity);
        }
    }

    public async Task<int> UpdateAsync(T entity)
    {
        using (SqlConnection db = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id")
                                            .Select(name => $"{name}=@{name}"));
            string sql = $"UPDATE {_tableName} SET {_} WHERE Id=@Id";
            int nRows = await db.ExecuteAsync(sql, entity);
            return nRows != 0 ? nRows : throw new ItemNotFoundException<T>();
        }
    }

    public async Task<int> DeleteAsync(T entity)
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = $"DELETE FROM {_tableName} WHERE Id=@Id";
            int nRows = await db.ExecuteAsync(sql, entity);
            return nRows != 0 ? nRows : throw new ItemNotFoundException<T>();
        }
    }

    virtual public async Task<T> GetByIdAsync(int id)
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = $"SELECT * FROM {_tableName} WHERE Id=@Id";
            return await db.QuerySingleOrDefaultAsync<T>(sql, new { Id = id })
                ?? throw new ItemNotFoundException<T>();
        }
    }

    virtual public async Task<List<T>> GetAllAsync()
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = $"SELECT * FROM {_tableName}";
            var result = await db.QueryAsync<T>(sql);
            return result.ToList();
        }
    }
}
