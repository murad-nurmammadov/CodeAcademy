using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace DapperPracticeApp.Repositories.Implements;

internal class ProductRepository <T> : GenericRepository<T>
{
    // TODO:
    public override List<T> GetAll()
    {
        using (SqlConnection db = new(_connString))
        {
            string sql = """
                SELECT * 
                FROM Products AS p
                JOIN Categories AS c
                ON p.CategoryId = c.Id;
                """;

            return db.Query<T>(sql).ToList();  // rows affected
        }
    }
}
