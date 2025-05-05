namespace Techan.ViewModels.ProductVM;

public class ProductCreateVM
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string ImageFileName { get; set; }
}
