namespace Techan.ViewModels.BrandVMs;

public class BrandUpdateVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public IFormFile? NewLogo { get; set; }
}
