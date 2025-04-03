using Interfaces;

namespace Models
{
    public class Student : ICodeAcademy
    {
        // Fields
        public static int Count;

        // Properties
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CodeEmail { get; set; }

        // Constructors
        static Student()
        {
            Count = 0;
        }

        public Student(string name, string surname)
        {
            Id = ++Count;
            Name = name;
            Surname = surname;
            GenerateEmail();
        }

        // Methods
        public static bool CheckName(string name)
        {
            if (name.Length > 2) { return true; }
            else { return false; }
        }

        public string GenerateEmail()
        {
            CodeEmail = $"{Name}.{Surname}{Id}@code.edu.az".ToLower();
            return CodeEmail;
        }
    }
}
