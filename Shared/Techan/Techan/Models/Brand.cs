namespace Techan.Models;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public string? LogoPath { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
