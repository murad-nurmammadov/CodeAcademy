namespace CW_2025_04_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TASK 1
            // string-in Contains metodunu overloadları ilə birlikdə custom yazın

            string text = "some text";

            Console.WriteLine(ContainsChar(text, 't'));
            Console.WriteLine();

            bool doesContain = text.Contains("ext");
            Console.WriteLine(doesContain);
            Console.WriteLine(ContainsStr(text, "ext"));

            // TASK 2
            /*
            Person abstract classınız olur Id, Name, Surname,Age propertyləri olur. 
            Id constructor vasitəsi ilə götürülmür hər object yarananda avtomatik 1-dən 
            başlayıb 1 vahid artaraq set olunur. 
            Digər dəyərlər olmadan object yaratmaq olmasın. 
            
            Name böyük hərflə başlamalıdır 3 simvoldan uzun olmalıdır.
            Age 0-dan kiçik olmamalıdır.
            GetInfo()  abstract methodu olur.

            Student classınız olur Persondan miras alır. Əlavə olaraq Grade propertysi 
            olur. Getİnfo() methodu override olunur studentin Adını soyadını ekrana 
            çıxardır və grade inə görə hərf ilə balını ekrana çıxardır (95⇒A,73⇒C)

            Teacher classiniz olur Persondan miras alır. Əlavə olaraq Salary propertsi 
            olur constructor vasitəsi ilə götürür. Teacher class i üçün ToString methodunu 
            override edin. Console a Teacher tipindən object verdikdə ekrana bütün 
            dəyərlərini çıxartsın.
            */
        }

        static bool ContainsChar(string text, char searchedChar)
        {
            foreach (char c in text)
            {
                if (c == searchedChar) return true;
            }

            return false;
        }

        static bool ContainsStr(string text, string searchedStr)
        {
            int subStrLen = searchedStr.Length;

            for (int i = 0; i + subStrLen <= text.Length; i++)
            {
                //Console.WriteLine(text[i..(i + subStrLen)]);

                if (text[i..(i + subStrLen)] == searchedStr)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
