namespace CodeAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            string text = Console.ReadLine();
            string reversedText = ReverseText(text);
            Console.WriteLine(reversedText);
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
    }
}
