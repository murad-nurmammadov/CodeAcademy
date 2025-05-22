using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;

namespace Techan.ViewModels.ProductVMs;

public class ProductCreateVM
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int BrandId { get; set; }
    public decimal Cost { get; set; }
    public int CategoryId { get; set; }

    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }

    public List<CategoryGetVM>? Categories { get; set; }
    public List<BrandGetVM>? Brands { get; set; }
}
