using Models;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student murad = new Student("Murad", "Nurmammadov");
            Console.WriteLine(murad.CodeEmail);

            Student davud = new Student("Davud", "Nurmammadov");
            Console.WriteLine(davud.CodeEmail);
        }
    }
}
