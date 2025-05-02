using Microsoft.EntityFrameworkCore;
using Techan.Models;

namespace Techan.Contexts;

public class TechanDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=TechanDb; Trusted_Connection=True; TrustServerCertificate=True;"); 
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Product> Products;
}
