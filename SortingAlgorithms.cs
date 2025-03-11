using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeAcademy
{
    internal class SortingAlgorithms
    {

        // TODO: Implement sorting algorithms and write test functions for each of them.

        #region Sorting Algorithms

        int[] SelectionSort(int[] array)
        {
            int currMin = 0;

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[currMin])
                    {
                        currMin = j;
                    }
                }

                // Swap
                array[i - 1] += array[currMin];
                array[currMin] = array[i - 1] - array[currMin];
                array[i - 1] -= array[currMin];
            }
            return array;
        }

        int[] unsortedArr = { 2, 8, 1, 3, 6, 7, 5, 4 };

        //int[] sortedArr = SelectionSort(unsortedArr);

        //foreach (int i in sortedArr) { Console.Write(i + " "); }


        int[] BubbleSort(int[] array)
        {
            return array;
        }

        int[] InsertionSort(int[] array)
        {
            return array;
        }

        int[] MergeSort(int[] array)
        {
            return array;
        }

        int[] QuickSort(int[] array)
        {
            return array;
        }

        int[] CocktailSort(int[] array)
        {
            // Bidirectional Bubble Sort
            return array;
        }

        int[] CombSort(int[] array)
        {
            return array;
        }

        #endregion

        //int[] unsortedArr = { 2, 8, 1, 3, 6, 7, 5, 4 };

    }
}