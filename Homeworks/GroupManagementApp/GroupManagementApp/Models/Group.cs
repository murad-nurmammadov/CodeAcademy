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
            string path = Path.Combine("..", "..", "..", "JSONs", $"{name}.json");
            Name = name;
            Students = _students;
        }

        public void AddStudent(Student student) { }
        public void RemoveStudent(Student student) { }
    }
}
