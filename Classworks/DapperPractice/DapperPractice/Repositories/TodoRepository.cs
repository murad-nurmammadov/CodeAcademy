using DapperPractice.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperPractice.Repositories;

internal class TodoRepository
{
    const string _connString = @"Server = DESKTOP-RQO3UFQ\SQLEXPRESS; Database = Tasks; TrustedConnection = True;";
    private IDbConnection _connection = new SqlConnection(_connString);

    public bool Add()
    {
        return true;
    }

    public bool Update()
    {
        return true;
    }

    public bool Delete()
    {
        return true;
    }

    public List<TodoItem> GetAll()
    {
        const string sql = "SELECT * FROM Items;";
        _connection.Query(sql);

        List<TodoItem> items = new();
        return items;
    }

    //public TodoItem GetById(int id)
    //{
    //    TodoItem item = new();
    //    return item;
    //}
}
