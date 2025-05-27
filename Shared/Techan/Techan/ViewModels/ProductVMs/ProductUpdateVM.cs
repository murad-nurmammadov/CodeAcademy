using Techan.Models;

namespace Techan.ViewModels.ProductVMs;

public class ProductUpdateVM
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}
