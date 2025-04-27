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
    public int Add(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id").Select(name => $"@{name}"));
            string sql = $"INSERT INTO {_tableName} VALUES ({_})";
            
            return conn.Execute(sql, item);  // rows affected
        }
    }

    public int Update(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string _ = string.Join(",", _propertyNames.Where(name => name != "Id").Select(name => $"{name}=@{name}"));
            string sql = $"UPDATE {_tableName} SET {_} WHERE Id=@Id";
            
            int numRowsAffected = conn.Execute(sql, item);
            if (numRowsAffected == 0) throw new ItemNotFoundException($"{typeof(T).Name} Not Found!");
            return numRowsAffected;
        }
    }

    public int Delete(T item)
    {
        using (SqlConnection conn = new(_connString))
        {
            string sql = $"DELETE FROM {_tableName} WHERE Id=@Id";
            
            int numRowsAffected = conn.Execute(sql, item);
            if (numRowsAffected == 0) throw new ItemNotFoundException($"{typeof(T).Name} Not Found!");
            return numRowsAffected;
        }
    }

    public T GetById(int id)
    {
        using (SqlConnection conn = new(_connString))
        {
            string sql = $"SELECT TOP 1 * FROM {_tableName} WHERE Id=@Id";
            return conn.QuerySingleOrDefault<T>(sql, new { Id = id }) ?? throw new ItemNotFoundException();
        }
    }

    virtual public List<T> GetAll()
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = $"SELECT * FROM {_tableName}";
            return db.Query<T>(sql).ToList();  // rows affected
        }
    }
}
