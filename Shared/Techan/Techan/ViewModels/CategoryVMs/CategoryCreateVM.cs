using System.ComponentModel.DataAnnotations;

namespace Techan.ViewModels.CategoryVMs;

public class CategoryCreateVM
{
    // For Create Post
    [MaxLength(64)]
    public string Name { get; set; }
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(16)]
    public string? Slug { get; set; }
    public int? ParentCategoryId { get; set; }

    // For Create View
    public List<CategoryGetVM>? ParentCategories { get; set; }
}
