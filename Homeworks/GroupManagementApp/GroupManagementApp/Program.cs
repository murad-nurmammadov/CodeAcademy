using GroupManagementApp.Models;

namespace GroupManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Program işləyən zaman ekrana gələn menyu:
            1
            Qruplara bax
            2
            Qrup yarat
            3
            Qrup sil
            4 Qrupa keç
            
            İstifadəçi qrup adını yazaraq silə və ya qrupa keçid edə bilər.
            
            Qrupa keçid etdikdən sonra ekrana gələn menyu:
            1 Tələbələrə bax
            2 Tələbə əlavə et
            3 Tələbəni sil
            4 Geri qayıt
            
            İstifadəçi tələbə kodunu yazaraq tələbəni silə bilər. Geri qayıt seçərsə ilk açılan meyu ekrana gələcək.
            */

            string path = Path.Combine("..", "..", "..", "JSONs");
            Directory.CreateDirectory(path);

            Student std1 = new Student("", "name 1", "surname 1", 21);
            Student std2 = new Student("", "name 2", "surname 2", 20);
            Student std3 = new Student("", "name 3", "surname 3", 22);

            Group group1 = new Group("BB104");
            group1.AddStudent(std1);
            group1.AddStudent(std3);

            GroupManager.CreateGroup(group1);









            // Console App

            string mainMenu = """
                1 -> Get group
                2 -> Create group
                3 -> Delete group

                4 -> Move into Group menu
                0 -> Exit
                """;

            string groupMenu = """
                1 -> Get Students
                2 -> Add Student
                3 -> Delete Student
                4 -> Go Back
                """;

        }
    }
}
