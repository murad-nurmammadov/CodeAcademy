namespace Techan.Models;

public class Slider : BaseEntity
{
    public string Subtitle { get; set; }
    public string Title { get; set; }
    public string Highlight { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string ButtonLink { get; set; }
    public string ImageFileName { get; set; }
}
