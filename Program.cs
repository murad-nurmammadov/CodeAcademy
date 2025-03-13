namespace CodeAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            //string text = Console.ReadLine();
            //string reversedText = ReverseText(text);
            //Console.WriteLine(reversedText);

            // Task 2
            //int months = Convert.ToInt32(Console.ReadLine());
            //PrintYearAndMonth(months);

            // Task 3
            //Console.WriteLine(CalculateFactorial(5));

            // Task 4
            string name = Console.ReadLine();
            string result = RemoveSpaces(name);
            Console.WriteLine(result);
        }

        #region Task 1
        // Daxil etdiyimiz mətni tərsinə çevirən metod yazın;
        // meselen: Hello World! => !dlroW olleH

        static string ReverseText(string text)
        {
            string reversedText = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedText += text[i];
            }

            return reversedText;
        }
        #endregion

        #region Task 2
        // Ayı daxil edirik, nəticəsini il və ay olaraq çıxaran metod yazın.
        // Məsələn,
        // 23 daxil edirik, ekrana çıxır: 1 il 11 ay
        // 24 daxil edirik, ekrana çıxır: 2 il
        // 7 daxil edirik, ekrana çıxır: 7 ay

        static void PrintYearAndMonth(int totalMonths)
        {
            int years = totalMonths / 12;
            int months = totalMonths % 12;

            Console.WriteLine(years + " years, " + months + " months");
        }
        #endregion

        #region Task 3
        // Verilen edein Faktorialı hesablayan metod yazın
        static int CalculateFactorial(int number)
        {
            int factorial = 1;

            if (number == 0) { return 1; }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
            }

            return factorial;
        }
        #endregion

        #region Task 4
        // Parametr olaraq 1 string dəyər qəbul edən və həmin string dəyəri icində
        // bosluqlar qalmayacaq hala gətirən metod.Misal olaraq, name = " Hikmet  Abbasov "
        // deyə bir variable-mız varsa onu yaratdigimiz metoda göndərdikdə variable-daki
        // dəyər "HikmətAbbasov" olmalıdır.

        static string RemoveSpaces(string text)
        {
            string output = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    output += text[i];
                }
            }

            return output;
        }
        #endregion
    }
}
