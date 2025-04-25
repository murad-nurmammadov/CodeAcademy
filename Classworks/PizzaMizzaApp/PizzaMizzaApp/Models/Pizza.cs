namespace PizzaMizzaApp.Models
{
    internal class Pizza
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        // Constructors
        public Pizza() { }
        public Pizza(int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Methods
        public override string ToString() { return $"Id: {Id} ||| {Name}, {Price}"; }
    }
}
