﻿namespace CodeAcademy.classwork.march14_classes.task_2
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
