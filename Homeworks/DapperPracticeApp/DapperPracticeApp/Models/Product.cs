namespace DapperPracticeApp.Models;

internal class Product
{
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    // Constructors
    public Product() { }
    public Product(int id, string name, decimal price, int categoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }

    // Methods
    public override string ToString()
    {
        return $"Id: {Id} ||| {Name}, {Price}";
    }
}
