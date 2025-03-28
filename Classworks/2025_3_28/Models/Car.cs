using System.Runtime.CompilerServices;

namespace Models
{
    public class Car
    {
        private double Mileage { get; set; }
        private double Fuel { get; set; }
        private double FuelConsumption { get; set; }
        private double TankCapacity { get; set; }

        public Car(double fuel = 20, double fuelConsumption = 10, double tankCapacity = 40)
        {
            if (fuel > tankCapacity)
            {
                throw new ArgumentException("Fuel cannot exceed tank capacity!");
            }

            Mileage = 0;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public bool Drive(double kilometer)
        {
            if (Fuel < FuelConsumption * kilometer)
            {
                Console.WriteLine("Not enough fuel");
                return false;
            }

            Fuel -= FuelConsumption * kilometer;
            Mileage += kilometer;
            return true;
        }

        public bool Refuel(double amount)
        {
            if (TankCapacity < Fuel + amount)
            {
                Console.WriteLine("Exceeds capacity!");
                return false;
            }

            Fuel += amount;
            return true;
        }

        public void Print()
        {
            Console.WriteLine($"Mileage: {Mileage}");
            Console.WriteLine($"Fuel: {Fuel}");
            Console.WriteLine($"Fuel Consumption: {FuelConsumption}");
            Console.WriteLine($"Tank Capacity: {TankCapacity}\n");
        }
    }
}
