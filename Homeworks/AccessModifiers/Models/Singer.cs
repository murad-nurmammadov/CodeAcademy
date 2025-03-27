namespace Models
{
    public class Singer
    {
        /*
        Singer class-ı olsun. Singer-in Name, Surname, Age prop-ları olsun. 
        Name və Surname max 100 uzunluqda set oluna bilər. Age max 170 ola bilər.
        */

        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

        public Singer(string name, string surname, byte age)
        {
            if (name.Length > 100 || surname.Length > 100)
            {
                throw new Exception("Singer's name or surname length cannot exceed 100.");
            }
            if (age > 170)
            {
                throw new Exception("Age cannot exceed 170");
            }
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
