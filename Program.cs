using System.Net.Http.Headers;
using CodeAcademy.homeworks.march18;

namespace CodeAcademy
{
    class Porgram()
    {
        static void Main()
        {
            /* 
            Proqram run olduqda bizden say istemelidi, sayi daxil etdikden sonra hemin uzunluqda 
            bir book arrayi yaradilmalidir daha sonra verdiyimiz say defe bizden book ucun lazim 
            olan butun inputlari daxil etmeyimizi istemelidi, dovrun her stepinde yeni bir book 
            obyekti yaranib array-e elave edilmelidir. Sonda daxil olunan bütün kitabları ad və 
            qiyməti ilə göstərsin
             */

            Console.WriteLine("Enter number of books to add:");
            uint count = Convert.ToUInt32(Console.ReadLine());

            Book[] books = new Book[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter no:");
                uint no = Convert.ToUInt32(Console.ReadLine());

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                float price = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Enter genre:");
                string genre = Console.ReadLine();

                Console.WriteLine();

                books[i] = new Book(no, name, price, genre);
            }

            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Name} -- {book.Price}");
            }
        }
    }
}