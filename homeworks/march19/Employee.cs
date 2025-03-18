namespace CodeAcademy.homeworks.march19
{
    class Employee
    {
        public string Name;
        public float Salary;

        public Employee(string name, float salary)
        {
            Name = name;
            Salary = salary;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Salary}");
        }
    }
}
