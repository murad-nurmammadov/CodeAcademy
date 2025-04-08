namespace BookProject.Models
{
    /*
    `Book` class yaradırsınız. `Base` classdan miras alır
    Memberlər:
    `string Author`
    `Category Category`
    `ctor(name, author, category)`
    `Id` avtomatik artsın (1-dən başlayaraq)
    */

    internal class Book : Base
    {
        // Properties
        public string Author { get; set; }
        public Category Category { get; set; }
        
        // Constructor
        public Book(string name, string author, Category category) : base(name)
        {
            Author = author;
            Category = category;
        }
    }
}
