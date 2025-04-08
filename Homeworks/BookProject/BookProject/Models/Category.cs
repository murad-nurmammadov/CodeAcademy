namespace BookProject.Models
{
    /*
    `Category` class yaradırsınız. `Base` classdan miras alır
    Memberlər:
    `ctor(name)`
    `Id` avtomatik artsın (1-dən başlayaraq)
    */

    internal class Category : Base
    {
        // Constructor
        public Category(string name) : base(name) { }        
    }
}
