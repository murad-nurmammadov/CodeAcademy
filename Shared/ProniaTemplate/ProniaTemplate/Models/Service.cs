﻿namespace ProniaTemplate.Models;

public class Service : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImagePath { get; set; }
}
