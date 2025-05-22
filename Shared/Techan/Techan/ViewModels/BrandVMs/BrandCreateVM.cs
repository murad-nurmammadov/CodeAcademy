using System.ComponentModel.DataAnnotations;

namespace Techan.ViewModels.BrandVMs;

public class BrandCreateVM
{
    [MaxLength(100)]
    public string Name { get; set; }
    public IFormFile? Logo { get; set; }
}
