using Models;

namespace AccessModifiers2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assistant assistant = new Assistant();
            Employee emp = new Employee("Murad", true, 7500);

            Console.WriteLine(emp);
            assistant.GiveFeedback(emp);
            assistant.GiveFeedback(emp);
            assistant.GiveFeedback(emp);
            Console.WriteLine(emp);
        }
    }
}   
