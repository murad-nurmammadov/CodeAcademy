using Models;

namespace AccessModifers3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Aşağıdakı memberlərdən ibarət User class yaradın
             - UserName - istifadəçinin istifadəçi adını ifadə edir
             - Password - İstifadəçinin şifrə dəyərini ifadə edir

            UserName dəyəri təyin olunmamış User obyekti yaradıla bilinməməlidir.
            UserName dəyərinin uzunluğu minimum 6, maksimum 25 ola bilər.

            Password dəyərinin uzunluğu minimum 8 , maksimum 25 ola bilər və 
            içərisində mütlər ən az 1 böyük, 1 kiçik hərf və 1 rəqəm olmalıdır.

            Daha sonra User-dan instance yaradın, bunun üçün username və password 
            dəyərlərini console-dan qəbul edin.

            User classin icinde asagidaki metodlar da olsun:
              - HasDigit - parametr olaraq string dəyər qəbul edib o dəyərdə rəqəm 
                varsa geriyə true yoxdusa false qaytaran metod
              - HasUpper -  parametr olaraq string dəyər qəbul edib o dəyərdə 
                uppercase varsa geriyə true yoxdursa false qaytaran metod
              - HasLower - parametr olaraq string dəyər qəbul edib o dəyərdə 
                lowercase varsa geriyə true yoxdursa false qaytaran metod
            */

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            User user = new User(username, password);

            Console.WriteLine($"{user.Username} - {user.Password}");
        }
    }
}
