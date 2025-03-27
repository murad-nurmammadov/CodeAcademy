using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CodeAcademy.classwork.march18.Task2
{
    internal class Car : Vehicle
    {
        public string Brand;
        public string Model;
        public float FuelCapacity;
        public float FuelFor1Km;
        public float CurrentFuel;

        public Car(int year, string brand, string model, float fuelCapacity,  float fuelFor1Km, string color="") 
            : base(year, color)
        {
            Brand = brand;
            Model = model;
            FuelCapacity = fuelCapacity;
            FuelFor1Km = fuelFor1Km;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Brand} {Model} {Year}");
        }

        public float Drive(float km)
        {
            float fuelRequired = FuelFor1Km * km;

            if (fuelRequired > CurrentFuel) {
                Console.WriteLine("Run out of fuel!");
                CurrentFuel = 0;
            }
            else
            {
                CurrentFuel -= fuelRequired;
            }
            
            return CurrentFuel;
        }
    }
}
