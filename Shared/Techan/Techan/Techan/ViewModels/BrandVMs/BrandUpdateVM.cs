using Techan.Models;

namespace Techan.ViewModels.BrandVMs;

public class BrandUpdateVM : BaseEntity
{
    public string Name { get; set; }
    public IFormFile? NewLogo { get; set; }
    public string? ExistingLogoPath {  get; set; }
}
