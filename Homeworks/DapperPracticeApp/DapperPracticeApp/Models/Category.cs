using System.Diagnostics;

namespace DapperPracticeApp.Models;

internal class Category
{
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }

    // Constructors
    public Category() { }
    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // Methods
    public override string ToString()
    {
        return $"Id: {Id} ||| {Name}";
    }
}
