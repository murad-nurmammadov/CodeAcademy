﻿namespace ProniaTemplate.ViewModels.ServiceVMs;

public class ServiceUpdateVM
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
}
