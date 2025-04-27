using System.Reflection;
using Dapper;
using DapperPracticeApp.Exceptions;
using DapperPracticeApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace DapperPracticeApp.Repositories.Implements;

internal class GenericRepository<T> : IRepository<T>
{
    // Properties
    protected readonly string _connString = @"Server=.\SQLEXPRESS; 
                                            Database=DapperPractice; 
                                            Trusted_Connection=True; 
                                            TrustServerCertificate=True;";

    protected readonly string _tableName;
    protected readonly List<string> _propertyNames = [];

    // Constructors
    public GenericRepository()
    {
        _tableName = typeof(T).Name + "s";
        PropertyInfo[] properties = typeof(T).GetProperties();
        _propertyNames = properties.Select(p => p.Name).ToList();
    }

    public GenericRepository(string tableName) : this()
    {
        _tableName = tableName;
    }

    // Methods
    public async Task<int> AddAsync(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id").Select(name => $"@{name}"));
            string sql = $"INSERT INTO {_tableName} VALUES ({_})";
            
            return await conn.ExecuteAsync(sql, item);  // rows affected
        }
    }

    public async Task<int> UpdateAsync(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id").Select(name => $"{name}=@{name}"));
            string sql = $"UPDATE {_tableName} SET {_} WHERE Id=@Id";

            int nRows = await conn.ExecuteAsync(sql, item);
            return nRows != 0 ? nRows : throw new ItemNotFoundException($"{typeof(T).Name} Not Found!");
        }
    }

    public async Task<int> DeleteAsync(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string sql = $"DELETE FROM {_tableName} WHERE Id=@Id";
            
            int nRows = await conn.ExecuteAsync(sql, item);
            return nRows != 0 ? nRows : throw new ItemNotFoundException($"{typeof(T).Name} Not Found!");
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        using (SqlConnection conn = new(_connString))
        {
            string sql = $"SELECT TOP 1 * FROM {_tableName} WHERE Id=@Id";
            return await conn.QuerySingleOrDefaultAsync<T>(sql, new { Id = id }) ?? throw new ItemNotFoundException();
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = $"SELECT * FROM {_tableName}";
            return (await db.QueryAsync<T>(sql)).ToList();  // rows affected
        }
    }
}
