namespace GroupManagementApp.Models
{
    internal class Student
    {
        /*
        Student:
        string Code
        string Name
        string Surname
        int Age
        */
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Student(string code, string name, string surname, int age)
        {
            Code = code;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
