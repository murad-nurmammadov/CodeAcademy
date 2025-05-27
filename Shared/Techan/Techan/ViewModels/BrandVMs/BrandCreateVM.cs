using System.ComponentModel.DataAnnotations;

namespace Techan.ViewModels.BrandVMs;

public class BrandCreateVM
{
    [MaxLength(64)]
    public string Name { get; set; }
    public IFormFile? Image { get; set; }
}
