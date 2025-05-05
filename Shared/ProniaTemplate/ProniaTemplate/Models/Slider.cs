namespace ProniaTemplate.Models;

public class Slider : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }

    public Slider(int id, string title, string description, decimal price, string imagePath) : base(id)
    {
        Title = title;
        Description = description;
        Price = price;
        ImagePath = imagePath;
    }
}
