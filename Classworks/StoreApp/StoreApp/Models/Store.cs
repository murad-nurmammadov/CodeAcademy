using StoreApp.Interfaces;
using StoreApp.Exceptions;

namespace StoreApp.Models
{
    internal class Store : IModel
    {
        // Fields
        private Product[] _products;

        // Properties
        public int Id { get; init; } = 0;
        public string Name { get; set; }
        public Product[] Products { get => _products; set { _products = value; } }

        // Costructors
        public Store(string name, Product[] products)
        {
            Id++;
            Name = name;
            _products = products;
        }

        // Methods
        public void AddProduct(Product product)
        {
            if (Products.Contains(product))
                throw new ProductAlreadyExistsException();

            Array.Resize(ref _products, Products.Length + 1);
            _products[^1] = product;
        }

        public void RemoveProduct(Product product)
        {
            if (!Products.Contains(product))
                throw new ProductNotFoundException();

            for (int i = 0; i < Products.Length - 1; i++)
            {
                if (_products[i] == product)
                {
                    for (int j = i; j < Products.Length - 1; j++)
                    {
                        _products[j] = _products[j + 1];
                    }
                    Array.Resize(ref _products, Products.Length - 1);
                    break;
                }
            }
        }

        public void ShowProductInfoByID(int id)
        {
            foreach (Product product in Products)
            {
                if (product.Id == id)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} ({product.CountAvailable}) - {product.Price}AZN");
                }
            }
        }
    }
}
