namespace Techan.ViewModels.BrandVMs;

public class BrandUpdateVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
}
