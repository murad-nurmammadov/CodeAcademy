using CodeAcademy.homeworks.march17;

namespace CodeAcademy
{
    class Porgram()
    {
        static void Main()
        {
            Student student = new Student("Murad", "Nurmammadov", "R11", 82);

            student.GetInfo();
            student.CheckGeaduation();
            student.GetDiplomDegree();
        }
    }
}