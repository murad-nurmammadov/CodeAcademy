namespace CodeAcademy
{
    class Porgram()
    {
        static void Main()
        {
            // Methods (2)

            // Task 1
            // Method Task: Min methodu yaradılır.Daxil olunan arrayın ən kiçik elementini tapır.
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, };
            Console.WriteLine(Min(nums));

            // Task 2
            /* Overload Tasks: Area deyə Method(lar) yaradılır.
                1. Çevrənin sahəsi
                   S = p*r² (p=3)
                2. Düzbucaqlının sahəsi
                   S = a*b
                3. Düzbucaqlı paralelpipedin tam səthinin sahəsi
                   S=2(a*b+a*c+b*c)
                4. Üçbucaqlının daxilinə çəkilmiş çevrənin sahəsi
                   S=p*r; p=(a+b+c)/2
             */
            Console.WriteLine(Area(4));
            Console.WriteLine(Area(4, 4));
            Console.WriteLine(Area(4, 4, 4));
            Console.WriteLine(Area(4, 4, 4, 4));

        }

        // Task 1
        static int Min(int[] nums)
        {
            int min = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) { min = nums[i]; }
            }

            return min;
        }

        // Task 2
        static float Area(float radius)
        {
            return radius * 3;
        }

        static float Area(float legth, float width)
        {
            return legth * width;
        }

        static float Area(float length, float width, float height)
        {
            return 2 * (length * width + length * height + width * height);
        }

        static float Area(float side1, float side2, float side3, float radius)
        {
            float p = (side1 + side2 + side3) / 2;
            return p * radius;
        }
    }
}