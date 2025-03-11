using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CodeAcademy
{
    internal class SearchingAlgorithms
    {
        // NOT-1: Interpolation ~5 sətir ChatGPT-dən götürdüm.
        // NOT-2: Fibonacci-nin kodu yaman çox trial-error oldu...
        // NOT-3: Binary bir sual var.

        #region Searching Algorithms
        int LinearSearch(int[] array, int start, int end, int searchedElement)
        {
            for (int i = start; i < end; i++)
            {
                if (array[i] == searchedElement) { return i; }
            }

            return -1;
        }

        // TODO: Why right taken out of range?
        int BinarySearch(int[] array, int left, int right, int searchedElement)
        {
            // TODO: Set as Default
            //int left = 0;
            //int right = array.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == searchedElement) { return mid; }
                else if (array[mid] < searchedElement) { left = mid + 1; }
                else { right = mid; }
            }

            return -1;
        }

        int TernarySearch(int[] array, int searchedElement)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int mid1 = left + (right - left) / 2;
                int mid2 = right - (right - left) / 2;

                if (array[mid1] == searchedElement) { return mid1; }
                else if (array[mid2] == searchedElement) { return mid2; }
                else if (array[mid1] < searchedElement && searchedElement < array[mid2])
                {
                    left = mid1 + 1;
                    right = mid2 - 1;
                }
                else if (searchedElement < array[mid1]) { right = mid1 - 1; }
                else { left = mid2 + 1; }
            }

            return -1;
        }

        int JumpSearch(int[] array, int searchedElement, int jumpSize)
        {
            // Uses Linear Search after constraining the range.

            int pivot = 0;

            while (pivot + jumpSize < array.Length)
            {
                if (array[pivot + jumpSize] > searchedElement)
                {
                    return LinearSearch(array, pivot, pivot + jumpSize, searchedElement);
                }
                else { pivot += jumpSize; }
            }

            return LinearSearch(array, pivot, array.Length, searchedElement);
        }

        int ExponentialSearch(int[] array, int searchedElement)
        {
            // Uses binary search after constraining the range.
            // Similar to Jump Search.

            int pivot = 1;

            if (array[0] == searchedElement) { return 0; }
            else if (array[1] == searchedElement) { return 1; }

            while (pivot * 2 < array.Length)
            {
                if (array[pivot * 2] > searchedElement)
                {
                    return BinarySearch(array, pivot, pivot * 2, searchedElement);
                }
                else { pivot *= 2; }
            }

            return BinarySearch(array, pivot, array.Length, searchedElement);
        }

        int InterpolationSearch(int[] array, int searchedElement)
        {
            // Conditions: Array needs to be (1) (at least almost) uniformly distributed and (2) sorted.

            // y = k * x + b 
            // y -> given (searchedElement); x -> required (foundIndex)
            // k = (array[right] - array[left]) / (right - left)
            // b = array[left]

            // x = (y - b) / k  ----  equation of line passing through two given points

            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                // ChatGPT
                if (array[right] == array[left]) // Prevent division by zero
                {
                    if (array[left] == searchedElement) return left;
                    break;
                }

                // We added left as offset. Without this, the result would ne an offset from zero
                // rather than from the left.
                int foundIndex = left + (searchedElement - array[left]) * (right - left) / (array[right] - array[left]);

                // ChatGPT
                if (foundIndex < left || foundIndex > right) return -2; // Prevent out-of-bounds access

                if (array[foundIndex] == searchedElement) { return foundIndex; }
                else if (array[foundIndex] < searchedElement)
                {
                    left = foundIndex + 1;
                }
                else
                {
                    right = foundIndex - 1;
                }
            }

            return -1;
        }

        #region Fibonacci Search
        int CountFibonacciNumbers(int endNum)
        {
            // pivots;
            int fib1 = 1;  // Start with 1, 2 instead of 0, 1.
            int fib2 = 2;

            int placeholder;
            int size = 2;

            while (fib1 + fib2 <= endNum)
            {
                placeholder = fib2;
                fib2 += fib1;
                fib1 = placeholder;

                size++;
            }

            return size;
        }

        int[] FibonacciSequence(int num)
        {
            int size = CountFibonacciNumbers(num) - 1;  // -1 because we need up to fib1, not fib2

            int[] fibSeq = new int[size];

            fibSeq[0] = 1;
            fibSeq[1] = 2;

            for (int i = 2; i < size; i++)
            {
                fibSeq[i] = fibSeq[i - 2] + fibSeq[i - 1];
            }

            return fibSeq;
        }

        int FibonacciSearch(int[] array, int searchedElement)
        {
            int[] fibSeq = FibonacciSequence(array.Length);
            int pivot = fibSeq.Length - 2;
            int index = fibSeq[^1];

            while (pivot >= 0)  // While fibSeq[steps] is valid statement
            {
                // Check whether update is needed 
                if (array[index] < searchedElement)
                {
                    index += fibSeq[pivot--];
                    //Console.WriteLine("INDEX " + index);
                }
                else if (array[index] > searchedElement)
                {
                    index -= fibSeq[pivot--];
                    //Console.WriteLine("INDEX " + index);
                }

                // Check if update worked (if any)
                if (array[index] == searchedElement) { return index; }

            }

            return -1;
        }

        #endregion

        #endregion



        // TODO: Write testing function

        // TEST -- just change function name
        // Note: Jump search takes additional jumpSize argument.

        //int[] array = [-21, -19, -13, -6, 0, 2, 9, 10, 13, 17, 22, 27];
        //array = [-24, -19, -15, -10, -8, -4, 0, 4, 8, 12, 16, 20];  // Almost uniform

        //Console.WriteLine("SEARCH");
        //for (int i = 0; i<array.Length; i++)
        //{
        //    int foundIndex = FibonacciSearch(array, array[i]);
        //    if (i == foundIndex)
        //    {
        //        Console.WriteLine(i);
        //        //Console.WriteLine("TRUE " + array[i] + " == " + array[foundIndex]);
        //    }
        //}

        //int searchedElement = 3;
        //int index = FibonacciSearch(array, searchedElement);
        //Console.WriteLine(index);
    }
}