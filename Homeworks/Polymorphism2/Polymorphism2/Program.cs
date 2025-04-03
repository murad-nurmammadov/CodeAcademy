using Models;

namespace Polymorphism2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mammal dog = new Mammal("Bulldog", 4, 23.2f, true);
            Mammal elephant = new Mammal("Elephant", 7, 327, false);

            Console.WriteLine(dog);
            Console.WriteLine(elephant);

            Bird eagle = new Bird("Eagle", 2, 12, true);
            Bird penguin = new Bird("Penguin", 3, 32, false);

            Console.WriteLine(eagle);
            Console.WriteLine(penguin);
        }
    }
}
