using System.Net.Http.Headers;
using System.Security.Cryptography;
using TodoListApp.Excepctions;
using TodoListApp.Models;

namespace TodoListApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            **Tələblər:**
            1. Əsas funksiyalar:
                - Yeni tapşırıq əlavə et
                - Tapşırıqları göstər
                - Tapşırığı tamamla
                - Tapşırığı sil
                - Çıxış et
            
            2. Sinif strukturu:
            - TaskBase (abstract class):
                - int Id
                - string Title
                - bool IsCompleted
                - virtual void Print() və ya abstract void Print()
            3. TaskItem (TaskBase-dən miras alır):
                - override void Print() – Tapşırığın başlığını və tamamlanma statusunu göstərir
            4. Static istifadə:
                - TaskManager (static class):
                - TaskItem[] tasks = new TaskItem[0]; yeni task əlavə olunduqca ölçüsü artsın
                - Əlavə etmə, silmə, göstərmə və tamamlanma üçün static metodlar yazılır.

            **Bonus:**
            Əgər istəsən, TaskItem-ə DateTime CreatedAt kimi bir property əlavə edib, tapşırığın
            yaradılma vaxtını da göstərmək olar.
            */

            string shortcut = "";

            while (shortcut != "0")
            {
                Console.WriteLine("===========================");
                Console.WriteLine("MENU");
                Console.WriteLine("1 -> Add Task");
                Console.WriteLine("2 -> Show Tasks");
                Console.WriteLine("3 -> Complete Task");
                Console.WriteLine("4 -> Detele Task");
                Console.WriteLine("5 -> Exit");
                Console.WriteLine("===========================");
                Console.WriteLine("Enter shortcut:");

                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "0": return;
                    case "1":
                        {
                            try
                            {
                                Console.WriteLine("Enter task title:");
                                string title = Console.ReadLine();
                                TaskManager.AddTask(new TaskItem(title));
                            }
                            catch(ArgumentNullException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case "2": { TaskManager.ShowTasks(); break; }
                    case "3":
                    case "4":
                        {
                            try
                            {
                                Console.WriteLine("Enter task id:");
                                int id = Convert.ToInt32(Console.ReadLine());

                                if (shortcut == "3") TaskManager.CompleteTask(id);
                                else TaskManager.DeleteTask(id);
                            }
                            catch (FormatException) { Console.WriteLine("Invalid ID!"); }
                            catch (TaskNotFoundException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    default: Console.WriteLine("Invalid shortcut! Try again..."); break;
                }
            }

        }
    }
}
