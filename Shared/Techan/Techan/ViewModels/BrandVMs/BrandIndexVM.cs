using Techan.ViewModels.CategoryVMs;

namespace Techan.ViewModels.BrandVMs;

public class BrandIndexVM
{
    public List<BrandGetVM> Brands { get; set; }
    public List<CategoryGetVM>? Categories { get; set; }
}
