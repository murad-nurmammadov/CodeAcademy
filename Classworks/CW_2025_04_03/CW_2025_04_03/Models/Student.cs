namespace CW_2025_04_03.Models
{
    public class Student : Person
    {
        public Student(string name, string surname, byte age) : base(name, surname, age) { }

        public override void GetInfo()
        {
            Console.WriteLine();
        }
    }
}
