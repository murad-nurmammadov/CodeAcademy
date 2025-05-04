using Techan.Models;

namespace Techan.ViewModels;

public class ProductViewModel
{
    public List<Brand> Brands{ get; set; }
    public List<Category> Categories { get; set; }
    public List<Product> Products { get; set; }

}
