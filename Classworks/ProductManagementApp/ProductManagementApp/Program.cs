using ProductManagementApp.Models;

namespace ProductManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("pr1", 4.99f);
            Product product2 = new Product("pr2", 4.99f);
            Product product3 = new Product("pr3", 4.99f);
            Product product4 = new Product("pr4", 4.99f);

            Manager<Product> productManager = new();

            productManager.Add(product1);
            productManager.GetAll();
            Console.WriteLine();

            productManager.Add(product2);
            productManager.Add(product3);
            productManager.GetAll();
            Console.WriteLine();

            productManager.Update(2, product4);
            productManager.GetAll();
            Console.WriteLine();

            productManager.Remove(1);
            productManager.GetAll();
            Console.WriteLine();

            Console.WriteLine(productManager.GetById(3));
            Console.WriteLine(productManager.GetById(5));
            Console.WriteLine();
        }
    }
}
