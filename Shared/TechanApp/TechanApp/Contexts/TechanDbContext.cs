using Microsoft.EntityFrameworkCore;

namespace TechanApp.Contexts;

public class TechanDbContext : DbContext
{
    public TechanDbContext(DbContextOptions options) : base(options) { }

    protected TechanDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
