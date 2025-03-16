using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.classwork
{
    internal class Worker
    {
        // Properties
        public string Name;
        public string Surname;
        public byte Experience;
        public float Payment;

        // Constructors
        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Worker(string name, string surname, byte experience) : this(name, surname)
        {
            Experience = experience;
        }

        public Worker(string name, string surname, byte age, byte experience, float payment) : this(name, surname, experience)
        {
            Payment = payment;
        }
    }
}
