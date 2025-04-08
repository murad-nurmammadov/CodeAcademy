namespace BookProject.Models
{
    /*
    `Base` class yaradırsınız. Bu classdan obyekt yaratmaq olmasın
    Memberlər:
    `int Id` - yalnız özündən və miras verdiyi classlardan set etmək olsun.
    `string Name` - yalnız özündən və miras verdiyi classlardan set etmək olsun
    */

    abstract internal class Base
    {
        // Field
        private static int _id = 0;

        // Properties
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        // Constructor
        public Base(string name)
        {
            Name = name;
            Id = ++_id;
        }
    }
}
