namespace PizzaMizzaApp.Models
{
    internal class Ingredient
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }

        // Constructor
        public Ingredient() { }
        public Ingredient(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Methods
        public override string ToString() { return $"Id: {Id} ||| {Name}"; }
    }
}
