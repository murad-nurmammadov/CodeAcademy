using HospitalProject.Exceptions;
using HospitalProject.Models;

namespace HospitalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Hospital hospital = new Hospital();

            // Manual data addition
            hospital.AddAppointment(new Appointment("Murad",
                                        "Davud",
                                        DateTime.Now,
                                        Convert.ToDateTime("04.08.2025 06:15:00")));

            hospital.AddAppointment(new Appointment("Murad",
                                                    "Davud",
                                                    Convert.ToDateTime("04.08.2025 13:00:00"),
                                                    Convert.ToDateTime("04.08.2025 13:30:00")));
            hospital.AddAppointment(new Appointment("Murad",
                                                    "Said",
                                                    Convert.ToDateTime("04.09.2025 07:30:00"),
                                                    Convert.ToDateTime("04.09.2025 08:15:00")));

            string shortcut = "";

            while (shortcut != "7")
            {
                Console.WriteLine("==================================");
                Console.WriteLine("MENU");
                Console.WriteLine("1 -> Add appointment");
                Console.WriteLine("2 -> End appointment");
                Console.WriteLine("3 -> Get all appointments");
                Console.WriteLine("4 -> Get this week's appointments (TODO)");
                Console.WriteLine("5 -> Get today's appointments");
                Console.WriteLine("6 -> Get not ended appointments");
                Console.WriteLine("7 -> Exit");
                Console.WriteLine("==================================");

                Console.WriteLine("Enter a shortcut:");
                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "1":
                        {
                            try
                            {
                                Console.WriteLine("Enter Doctor");
                                string doctor = Console.ReadLine();
                                Console.WriteLine("Enter Patient");
                                string patient = Console.ReadLine();
                                Console.WriteLine("Enter Start Date (mm/dd/yyyy hh/mm/ss)");
                                DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Enter End Date (mm/dd/yyyy hh/mm/ss)");
                                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                                Appointment newAppointment = new Appointment(doctor, patient, startDate, endDate);
                                hospital.AddAppointment(newAppointment);
                            }
                            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                            catch (FormatException) { Console.WriteLine("Incorrect datetime format!"); }
                            catch (AppointmentOverlapException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Enter appointment no:");
                                int no = Convert.ToInt32(Console.ReadLine());
                                hospital.EndAppointment(no);
                            }
                            catch (FormatException) { Console.WriteLine("NO must be positive integer!"); }
                            catch (AppointmentNotFoundException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case "3": hospital.GetAllAppointments(); break;
                    case "4": hospital.GetWeeklyAppointments(); break;
                    case "5": hospital.GetTodaysAppointments(); break;
                    case "6":
                        {
                            foreach (Appointment appointment in hospital.Appointments)
                            {
                                if ((DateTime.Now < appointment.EndDate)
                                && (appointment.StartDate != appointment.EndDate))
                                    Console.WriteLine(appointment);
                            }
                            break;
                        }
                    case "7": return;
                    default: Console.WriteLine("Invalid shortcut! Try again..."); break;
                }
            }
        }
    }
}
