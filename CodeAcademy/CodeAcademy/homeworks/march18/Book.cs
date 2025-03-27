namespace CodeAcademy.homeworks.march18
{
    class Book : Product
    {
        // Book class: Productdan miras alır, Genre; 
        // Genre dəyəri təyin olunmadan Book yaradıla bilməz

        public string Genre;

        public Book(uint no, string name, float price, string genre) : base(no, name, price)
        {
            Genre = genre;
        }
    }
}
