using System.ComponentModel.DataAnnotations;

namespace Techan.ViewModels.CategoryVMs;

public class CategoryCreateVM
{
    [MaxLength(100)]
    public string Name { get; set; }
}
