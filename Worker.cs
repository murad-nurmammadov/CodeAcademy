using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy
{
    internal class Worker
    {
        // Properties
        public string Name;
        public string Surname;
        public byte Age;
        public bool IsMarried;
        public float payment;

        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Worker(string name, string surname, byte age, bool isMarried) : this (name, surname)
        {
            Age = age;
            IsMarried = isMarried;
        }

        public Worker(string name, string surname, byte age, bool isMarried, float payment) : this (name, surname, age, isMarried)
        {
            //payment = 
        }


    }
}
