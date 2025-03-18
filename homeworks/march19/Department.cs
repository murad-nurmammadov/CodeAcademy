namespace CodeAcademy.homeworks.march19
{
    class Department
    {
        public string Name;
        public int EmployeeLimit;
        public Employee[] Employees;

        public Department(string name, int employeeLimit)
        {
            Name = name;
            EmployeeLimit = employeeLimit;
            Employees = [];
        }

        public void AddEmployer(Employee emp)
        {
            if (Employees.Length < EmployeeLimit)
            {
                Add(ref Employees, emp);
            }
            else
            {
                Console.WriteLine("Employee Limit! Can't add new employee...");
            }
        }

        static void Add(ref Employee[] emps, Employee emp)
        {
            Employee[] updatedEmps = new Employee[emps.Length + 1];
            updatedEmps = [.. emps, emp];
            emps = updatedEmps;
        }

        public void GetAllEmployees()
        {
            foreach (Employee emp in Employees)
            {
                emp.ShowInfo();
            }
        }
    }
}
