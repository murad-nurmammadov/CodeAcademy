using StoreApp.Interfaces;
using System.Data;

namespace StoreApp.Models
{
    internal class Product : IModel
    {
        public static int Id { get; } = 0;
        public string Name { get; set; }
        public int CountAvailable { get; set; }
        public float Price { get; set; }

        public Product(string name, int countAvailable, float price)
        {
            ++Id;
            Name = name;
            CountAvailable = countAvailable;
            Price = price;
        }
    }
}
