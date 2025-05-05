using System.ComponentModel.DataAnnotations;

namespace Techan.ViewModels.BrandVM;

public class BrandCreateVM
{
    [MaxLength(100)]
    public string Name { get; set; }
}
