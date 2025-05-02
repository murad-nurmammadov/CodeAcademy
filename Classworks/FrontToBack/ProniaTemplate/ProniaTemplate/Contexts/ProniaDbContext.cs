using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Models;

namespace ProniaTemplate.Contexts;

public class ProniaDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=ProniaDbContext; Trusted_Connection=True; TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Blog> Blogs { get; set; }
}
