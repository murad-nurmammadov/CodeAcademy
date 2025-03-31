namespace Models
{
    public class Singer
    {
        /*
        Singer class-ı olsun. Singer-in Name, Surname, Age prop-ları olsun. 
        Name və Surname max 100 uzunluqda set oluna bilər. Age max 170 ola bilər.
        */

        private string _name;
        private string _surname;
        private byte _age;

        public string Name
        {
            get { return _name; }
            set { if (value.Length <= 100) { _name = value; } }
        }

        public string Surname
        {
            get { return _surname; }
            set { if (value.Length <= 100) { _surname = value; } }
        }

        public byte Age
        {
            get { return _age; }
            set { if (value <= 170) { _age = value; } }
        }

        public Singer(string name, string surname, byte age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
