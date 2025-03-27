namespace CodeAcademy.classwork.march17.task1
{
    internal class Person
    {
        // Properties
        public string Name;
        public int Age;
        public string Profession;

        // Constructors
        public Person(string name, byte age, string profession)
        {
            Name = name;
            Age = age;
            Profession = profession;
        }

        // Methods
        public void Introduce()
        {
            Console.WriteLine($"Salam, mənim adım {Name}. {Age} yaşım var. {Profession} ixtisası ilə məşğulam.");
        }

    }
}
