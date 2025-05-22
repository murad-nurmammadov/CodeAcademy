using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;

namespace Techan.ViewModels.ProductVMs;

public class ProductIndexVM
{
    public List<CategoryGetVM> Categories { get; set; }
    public List<ProductGetVM> Products { get; set; }
}
