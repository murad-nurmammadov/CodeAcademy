namespace GroupManagementApp.Models
{
    internal class Group
    {
        /*
        Group:
        -string Name
        -List<Student> students
        */

        List<Student> _students = new();

        public string Name { get; }
        public List<Student> Students { get; set; }

        public Group(string name)
        {
            Name = name;
            Students = _students;

            string path = Path.Combine("..", "..", "..", "JSONs", $"{name}.json");
        }

        public void AddStudent(Student student) { }
        public void RemoveStudent(Student student) { }
    }
}
