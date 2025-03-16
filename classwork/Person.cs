using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.classwork
{
    internal class Person
    {
        // Properties
        public string Name;
        public int Age;

        // Constructors
        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        // Methods
        public void Introduce()
        {
            Console.WriteLine($"My name is {Name}, I'm {Age} years old.");
        }

    }
}
