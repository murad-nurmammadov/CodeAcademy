namespace MVC_Practice.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Product() { }
    public Product(int id, string name, decimal price, int categoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
}
