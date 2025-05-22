namespace Techan.Models;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public string? ImagePath { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public DateTime DateAdded { get; set; }
}
