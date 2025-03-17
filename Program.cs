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
        }

        static int Min(int[] nums)
        {
            int min = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) { min = nums[i]; }
            }

            return min;
        }
    }
}