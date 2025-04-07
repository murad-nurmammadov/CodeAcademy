namespace HospitalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: Hospital class – GetWeeklyAppointments()

            /*
            Menu:
            1. Appointment yarat
            2. Appointment-i bitir
            3. Bütün appointment-lərə bax
            4. Bu həftəki appointment-lərə bax
            5. Bugünki appointment-lərə bax
            6. Bitməmiş appointmentlərə bax
            7. Menudan çıx
            */

            string shortcut = "";

            while (shortcut != "7")
            {
                Console.WriteLine("==================================");
                Console.WriteLine("MENU");
                Console.WriteLine("1 -> Add appointment");
                Console.WriteLine("2 -> End appointment");
                Console.WriteLine("3 -> Get all appointments");
                Console.WriteLine("4 -> Get this week's appointments");
                Console.WriteLine("5 -> Get today's appointments");
                Console.WriteLine("6 -> Get "); // ???
                Console.WriteLine("7 -> Exit");
                Console.WriteLine("==================================");

                Console.WriteLine("Enter a shortcut:");
                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "1":
                        {

                            break;
                        }
                    case "2":
                        {

                            break;
                        }
                    case "3":
                        {

                            break;
                        }
                    case "4":
                        {

                            break;
                        }
                    case "5":
                        {

                            break;
                        }
                        {

                            break;
                        }
                    case "6":
                        {

                            break;
                        }
                    case "7": return;
                    default: Console.WriteLine("Invalid shortcut! Try again..."); break;
                }
            }
        }
    }
}
