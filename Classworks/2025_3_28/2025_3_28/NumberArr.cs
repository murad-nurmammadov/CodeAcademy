namespace _2025_3_28
{
    static class ArrMethods
    {
        public static (int, int) FindMinMax(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];

            foreach (int num in arr)
            {
                if (num < min) { min = num; }
                else if ( num > max) { max = num; }
            }

            return (min, max);
        }

        public static void PrintCopy(int[] arr)
        {
            int[] arrCopy = [..arr];

            foreach (int num in arrCopy) { Console.Write($"{num} "); }
            Console.WriteLine();
        }

        public static int[] RemoveNumAtIndex(ref int[] arr, int index)
        {
            for (int i = index; i <= arr.Length - 2; i++)
            {
                arr[i] = arr[i + 1];
            }

            Array.Resize(ref arr, arr.Length - 1);

            return arr;
        }

        public static int[] Add(int[] arr, int num)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[^1] = num;
            return arr;
        }

        public static void Remove(ref int[] arr, int numToDel)
        {
            for (int i = 0; i < arr.Length; i++)
            {
               if (arr[i] == numToDel)
                {
                    arr = RemoveNumAtIndex(ref arr, i);
                    return;
                }
            }
            Console.WriteLine("Not Found!");
        }
    }
}
