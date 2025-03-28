using System.Threading.Channels;
using Models;

namespace _2025_3_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("TASK 1:");
            int[] arr = { 2, 3, 7, 4, 5, 5, 12, 66, 32, 21, 22, };

            (int min, int max) = ArrMethods.FindMinMax(arr);
            Console.WriteLine($"Min: {min}; Max: {max}");

            ArrMethods.PrintCopy(arr);
            int[] updated1 = ArrMethods.RemoveNumAtIndex(ref arr, 2);
            ArrMethods.PrintCopy(updated1);

            int[] update2 = ArrMethods.Add(updated1, 100);
            ArrMethods.PrintCopy(update2);

            ArrMethods.Remove(ref update2, 22);
            ArrMethods.PrintCopy(update2);


            // Task 2
            Console.WriteLine("\nTASK 2:");
            Car car = new Car(40, 10, 100);
            car.Print();
            car.Drive(3);
            car.Print();
            car.Refuel(40);
            car.Print();



            // Task 3   
            Console.WriteLine("\nTASK 3:");

            Console.WriteLine("=========================");
            Console.WriteLine("MENU");
            Console.WriteLine("0 -> Print Info");
            Console.WriteLine("1 -> Drive");
            Console.WriteLine("2 -> Refuel");
            Console.WriteLine("=========================");

            string shortcut = "0";

            while (true)
            {                
                Console.WriteLine("\nEnter Shortcut:");
                shortcut = Console.ReadLine();

                switch (shortcut)
                {
                    case "0": { car.Print(); break; }
                    case "1":
                        {
                            Console.WriteLine("Enter km:");
                            double km = double.Parse(Console.ReadLine());
                            car.Drive(km);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter amount:");
                            double amount = double.Parse(Console.ReadLine());
                            car.Refuel(amount);
                            break;
                        }
                    default: { Console.WriteLine("Invalid Option!"); break; } 
                }
            }
            Console.WriteLine("Menu");
        }
    }
}
