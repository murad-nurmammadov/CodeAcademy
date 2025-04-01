using Models;
using System.Transactions;

namespace UserApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Program cs də bir User arrayiniz olur.
            Layihə run olunduqda belə bir pəncərə açılmalıdır.

            **İstifadəçi console a 2 daxil etdikdə ondan yeni user yaratmaq üçün dəyərləri tələb etməlisiniz və həmin dəyərlər ilə User yaradıb User arrayinizdə saxlamalısınız.**
            **İstifadəçi console a 1 daxil etdikdə Username və password istəməlisiniz. Həmin username və password arraydə mövcuddursa istifadəçiyə salam verin əks halda “İstifadəçi adı və ya parol yanlışdır” outputunu göstərin.**

            *Optional* Eyni emaildə və ya eyni username də userlər ola bilməz.*
            */

            User user1 = new User("murad", "murad@gmail.com", "Murad2003");
            User user2 = new User("davud", "davud@gmail.com", "Davud2005");

            User[] users = { user1, user2 };


            string input = "";

            while (input != "1" || input != "2")
            {
                Console.WriteLine("WELCOME!");
                Console.WriteLine("1. Enter");
                Console.WriteLine("2. Sign In");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter password:");
                            string password = Console.ReadLine();

                            if (IsAuthenticUser(users, username, password))
                            {
                                Console.WriteLine("Hello!");
                            }
                            else { Console.WriteLine("User Not Found!"); }

                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("Enter username:");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter email:");
                            string email = Console.ReadLine();

                            Console.WriteLine("Enter password:");
                            string password = Console.ReadLine();

                            // TODO: Check that user has different name and password

                            User newUser = new User(username, email, password);

                            Array.Resize(ref users, users.Length + 1);
                            users[^1] = newUser;

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid Option!"); break;
                        }
                }
            }
        }

        public static bool IsAuthenticUser(User[] users, string username, string password)
        {
            foreach (User user in users)
            {
                if (user.Username == username || user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
