﻿namespace ProniaTemplate.Models;

public class Blog : BaseEntity
{
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }  // 1-1-310x220.jpg
}
