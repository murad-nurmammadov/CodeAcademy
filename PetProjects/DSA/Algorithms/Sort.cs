namespace Algorithms
{
    public static class Sort
    {

        // TODO: Implement Insertion, Merge, and Quick sorting algorithms

        // ChatGPT Suggestions:
        // 1. We can assume array isSorted unless any changes happen in Bubble, Cocktail, Comb

        static void Swap(ref int[] array, int index1, int index2)
        {
            array[index1] += array[index2];
            array[index2] = array[index1] - array[index2];
            array[index1] -= array[index2];
        }


        #region Selection Sort
        /// <summary>
        /// Iteratively replaces current element with minimum of the right
        /// </summary>
        public static int[] Selection(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int currMin = i;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[currMin])
                    {
                        currMin = j;
                    }
                }

                // Swap element at i with the one at currMin
                if (i != currMin)
                {
                    array[i] += array[currMin];
                    array[currMin] = array[i] - array[currMin];
                    array[i] -= array[currMin];
                }
            }

            return array;
        }
        #endregion

        #region Bubble Sort
        /// <summary>
        /// Iteratively swap adjacent elements until array is sorted
        /// </summary>
        public static int[] Bubble(int[] array)
        {
            bool isSorted = false;
            int sortedCount = 0;  // num of sorted elements

            while (!isSorted)
            {
                // Assume isSorted unless any changes are made
                isSorted = true;

                for (int i = 0; i < array.Length - 1 - sortedCount; i++)
                {
                    if (array[i + 1] < array[i])
                    {
                        Swap(ref array, i, i + 1);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }

            return array;
        }
        #endregion

        #region Insertion Sort
        public static int[] Insertion(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {

            }

            return array;
        }
        #endregion

        #region Merge Sort
        public static int[] Merge(int[] array)
        {
            return array;
        }
        #endregion

        #region Quick Sort
        public static int[] Quick(int[] array)
        {
            return array;
        }
        #endregion

        #region Cokctail Sort
        /// <summary>
        /// Bidirectional Bubble Sort
        /// </summary>
        public static int[] Cocktail(int[] array)
        {
            bool isSorted = false;
            int sortedCount = 0;  // count of sorted elements to the left or to the right (depending on situation)

            while (!isSorted)
            {
                // Forward Bubble   
                isSorted = true; // Assume isSorted unless any changes are made

                for (int i = sortedCount; i < array.Length - 1 - sortedCount; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array, i, i + 1);
                        isSorted = false;
                    }
                }

                // Backward Bubble
                isSorted = true;  // Assume isSorted unless any changes are made
                for (int i = array.Length - 1 - sortedCount; i > sortedCount; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        Swap(ref array, i, i - 1);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }

            return array;
        }
        #endregion

        #region Comb Sort
        /// <summary>
        /// Bubble sort with varying distances between compared elements (from high to low)
        /// </summary>
        public static int[] Comb(int[] array)
        {
            int margin = array.Length - 1;
            float shrinkFactor = 1.3f;

            while (true)
            {
                // Assume array isSorted unless any swaps are made
                bool isSorted = true;  // sorted w.r.t. the current margin

                for (int i = 0; i + margin < array.Length; i++)
                {
                    if (array[i] > array[i + margin])
                    {
                        Swap(ref array, i, i + margin);
                        isSorted = false;
                    }
                }

                if (isSorted && margin == 1) { break; }
                else if (isSorted)
                {
                    margin = Math.Max(1, Convert.ToInt32(Math.Floor(margin / shrinkFactor)));
                }
            }

            return array;
        }
        #endregion
    }
}
