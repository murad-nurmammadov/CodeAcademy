namespace BookProject.Models
{
    /*
    `Library` class yaradırsınız. `Base` classdan miras alır
    Memberlər:
    `Book[] _books`
    `ctor(name)`
    `Id` avtomatik artsın (1-dən başlayaraq)
    `AddBook(Book book)` - kitabxanaya kitab əlavə etmək üçün
    `ListAllBooks()` - bütün kitabları ekranda göstərmək üçün
    */

    internal class Library : Base
    {
        // Fields
        private Book[] _books = [];

        // Properties
        public string Name { get; set; }

        // Constructor
        public Library(string name) : base(name) { }

        // Methods
        public void AddBook(Book book) { }

        public void ListAllBooks() { }
    }
}
