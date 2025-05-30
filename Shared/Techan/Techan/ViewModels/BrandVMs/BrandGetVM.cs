﻿using Techan.ViewModels.CategoryVMs;

namespace Techan.ViewModels.BrandVMs;

public class BrandGetVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImagePath { get; set; }

    public int? ItemCount { get; set; }
}
