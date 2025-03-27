namespace Models
{
    public class Library
    {
        public string Name { get; set; }
        private Book[] Books { get; set; }

        public Library(string name, Book[] books)
        {
            Name = name;
            Books = books;
        }

        public void Add(Book book)
        {
            Book[] updatedBooks = new Book[Books.Length + 1];
            updatedBooks = [..Books, book];
            Books = updatedBooks;
        }

        public void Remove(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    book.Id = -1;
                    return;
                }
            }
            
            Console.WriteLine("Book Not Found!");
        }

        public void ShowBooks()
        {
            foreach(Book book in Books) { Console.WriteLine(book); }
            Console.WriteLine("===============");
        }
    }
}
