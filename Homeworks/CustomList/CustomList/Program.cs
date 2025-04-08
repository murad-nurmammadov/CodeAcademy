namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ListInt class-ı yaradın. İçində private int[] array-ı olsun.Indexer
            vasitəsi ilə obyektə index yazdıqca o indexə uyğun həmin private arrayın 
            həmin indexinə uyğun elementini get və set etmək olsun. 

            ListInt class-ı daxilindəki methodlar:
            Capacity -> Array dolduqdan sonra neçə vahid artdığını desin.
            Count -> List-dəki elementlərin sayını göndərir.

            Add(int num)
            Add(params int[] nums) - Göndərilən parametrləri arraya daxil edir.
            Contains(int num) - Göndərilən ədəd array-da varsa true yoxdursa false qaytarır.
            Pop() - Array-ın sonuncu elementini arraydan silir və həmin elementi geri qaytarır.
            Sum() - Array-ı cəmləyir.
            ToString() - Array-ın elementlərini tək sıra geri qaytarır.
            Remove(int num) - Göndərilən element array-da varsa onu arraydan silsin.
            Average() - Arraydakı elementlərin ədədi ortasını float olaraq geri qaytarır.
            IndexOf(int num) - Göndərilən elementin indeksini geri qaytarır.
            ---------------------------------------------------------------------------------------------------------
            LastIndexOf(int num) - Göndərilən elementin sonuncu indeksini geri qaytarır
            Insert(int num, int index) - Göndərilən elementi daxil olunan indeksə əlavə edib sonrakı elementləri 1 indeks sağa sürüşdürür.
             */

            ListInt list = new ListInt(5);

            list.IntArr = [5, 4, 7, 1, 0, 6];

            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Pivot);
            Console.WriteLine(list.Average());

            list.Add(0);
            list.Add(4);
            list.Add(4);
            list.Add(4);

            list.Insert(4, 11);

            list.Pop();
            list.Pop();

            list.Add(2);
            list.Add(5);
            list.Add(1);

            list.Remove(5);
            list.Remove(1);
             
            Console.WriteLine(list);

            Console.WriteLine(list.IndexOf(4));
            Console.WriteLine(list.LastIndexOf(4));

            Console.WriteLine(list.Contains(1));
            Console.WriteLine(list.Contains(22));

            Console.WriteLine(list[1]);
        }
    }
}
