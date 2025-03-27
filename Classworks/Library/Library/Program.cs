using Models;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(0, "The Alchemist", "Paulo Coelho", 1988);
            Book book2 = new Book(1, "Mindset", "Carol Dweck", 2006);

            Library library = new Library("MuradLib", [book1, book2]);

            library.ShowBooks();
            library.Remove(1);
            library.ShowBooks();
        }
    }
}
