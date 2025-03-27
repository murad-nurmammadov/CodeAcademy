using CodeAcademy.DSA.DataStructures;

namespace CodeAcademy
{
    class Porgram
    {
        static void Main()
        {
            // Sorting Algorithms
            int[] unsortedArr = { 2, 8, 1, 0, 3, 6, 7, 5, 4, 9 };
            //Console.WriteLine(String.Join(' ', Sort.Merge(unsortedArr)));

            //CStack<int> stack = new CStack<int>(5);
            //stack.PrintItems();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);

            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.PrintItems();


            CQueue<int> queue = new CQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();


            /*
            Singer class-ı olsun. Singer-in Name, Surname, Age prop-ları olsun. Name və Surname 
            max 100 uzunluqda set oluna bilər. Age max 170 ola bilər.

            Song class-ı olsun. Song-un Name, Genre, Singer(agregation) prop-ları olsun. Name 
            max 100 uzunluqda set oluna bilər. Genre yalnız "Pop", "Rock", "Jazz", "Techno" bu 
            value-lardan biri ola bilər. Məsələn  "Classic" ola bilməz, yalnız göstərilənlərdən 
            biri set olunmalıdır.

            Song-un rating-ləri olsun. AddRating, GetAverageRating metodları ilə funksionallıq 
            təmin olunsun.
            */
        }
    }
}
