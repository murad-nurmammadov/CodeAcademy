using Models;

namespace Animal1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("TASK 1");

            Mammal happyMammal = new Mammal("Kung Fu Panda", 8, 92.6f, true);
            Bird angryBird = new Bird("Yellow", 3, 4.2f, true);

            angryBird.PrintInfo();
            Console.WriteLine();


            // Task 2

            Console.WriteLine("TASK 2");

            int CalculateFactorial(int num)
            {
                int factorial = num;

                if (num == 1) { return 1; }
                else
                {
                    num--;
                    factorial *= CalculateFactorial(num);     
                }

                return factorial;
            }

            Console.WriteLine(CalculateFactorial(5));
        }
    }
}
