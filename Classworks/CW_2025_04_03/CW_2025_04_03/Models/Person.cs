using System.Xml.Linq;

namespace CW_2025_04_03.Models
{
    public abstract class Person
    {
        private static int _count = 1;
        private string _name;
        private string _surname;
        private string _email;

        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (char.IsUpper(value[0]) && value.Length > 3)
                {
                    _name = value;
                }
            }
        }

        public string Surname { get; set; }
        public byte Age { get; set; }

        protected Person(string name, string surname, byte age)
        {
            Id = _count++;

            if (char.IsUpper(name[0]) && name.Length > 3)
            {
                Name = name;
            }

            if (age > 0) { Age = age; }
        }

        public abstract void GetInfo();
    }
}
