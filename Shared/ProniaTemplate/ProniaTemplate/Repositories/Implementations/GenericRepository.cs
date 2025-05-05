using Dapper;
using Microsoft.Data.SqlClient;
using ProniaTemplate.Exceptions;
using ProniaTemplate.Repositories.Interfaces;
using System.Data;

namespace ProniaTemplate.Repositories.Implementations;

public class GenericRepository<T> : IRepository<T>
{
    private readonly string _connString = @"
        SERVER=.\SQLEXPRESS;
        DATABASE=ProniaDB;
        Trusted_Connection=True;
        TrustServerCertificate=True;
        ";
    protected readonly string tableName = typeof(T).Name + "s";
    protected readonly List<string> propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
    private readonly string notFoundMessage = $"{typeof(T).Name} Not Found!";
    protected IDbConnection _connection { get => new SqlConnection(_connString); }

    public GenericRepository() { }
    public GenericRepository(string tableName)
    {
        this.tableName = tableName;
    }

    public async Task<int> AddAsync(T entity)
    {
        string sql = $"INSERT INTO {tableName} VALUES {propertyNames.Where(name => name != "Id").Select(name => $"@{name}")}";
        using var db = _connection;
        return await db.ExecuteAsync(sql, entity);
    }

    public async Task<int> DeleteAsync(T entity)
    {
        string sql = $"DELETE FROM {tableName} WHERE Id=@Id";
        using var db = _connection;
        int nRows = await db.ExecuteAsync(sql, entity);
        return nRows != 0 ? nRows : throw new ItemNotFoundException(notFoundMessage);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        string sql = $"UPDATE {tableName} SET {propertyNames.Where(name => name != "Id").Select(name => $"{name}=@{name}")} WHERE Id=@Id";
        using var db = _connection;
        int nRows = await db.ExecuteAsync(sql, entity);
        return nRows != 0 ? nRows : throw new ItemNotFoundException(notFoundMessage);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        string sql = $"SELECT * FROM {tableName} WHERE Id=@Id";
        using var db = _connection;
        T entity = await db.QuerySingleOrDefault(sql, new { Id = id });
        return entity ?? throw new ItemNotFoundException(notFoundMessage); 
    }

    public async Task<List<T>> GetAllAsync()
    {
        string sql = $"SELECT * FROM {tableName}";
        using var db = _connection;
        var entities = await db.QueryAsync<T>(sql);
        return entities.ToList();
    }
}
