namespace Techan.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public int? ParentCategoryId { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
