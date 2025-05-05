namespace ProniaTemplate.Models;

public class Service : BaseEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Service(int id, string imagePath, string title, string description) : base(id)
    {
        ImagePath = imagePath;
        Title = title;
        Description = description;
    }
}
