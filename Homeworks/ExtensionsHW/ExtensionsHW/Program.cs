using Extensions;

namespace ExtensionsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 21;
            Console.WriteLine(age.IsOdd());
            Console.WriteLine(age.IsEven());

            string password1 = "Murad2003";
            string password2 = "nmurad";
            Console.WriteLine(password1.HasDigit());
            Console.WriteLine(password2.HasDigit());
            Console.WriteLine(password1.CheckPassword());
            Console.WriteLine(password2.CheckPassword());

            string name = "mUrAd";
            Console.WriteLine(name.Capitalize());
        }
    }
}
