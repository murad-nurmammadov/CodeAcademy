namespace ProductManagementApp.Models
{
    internal class Product : BaseEntity
    {
        // Properties
        public string Name { get; set; }
        public float Price { get; set; }
        private static int _id = 1;


        // Constructor
        public Product(string name, float price) : base(_id++)
        {
            Name = name;
            Price = price;
        }

        // Methods
        public override string ToString()
        {
            return $"{Id}. {Name} | {Price} USD";
        }
    }
}
