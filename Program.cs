using CodeAcademy.homeworks.march19;

namespace CodeAcademy
{
    class Porgram
    {
        static void Main()
        {
            /*
            Employee class: Name, Salary; ShowInfo()
            Name ve salary teyin edilmemish employee obyekti yaratmaq olmaz.

            Department
            - Name
            - EmployeeLimit -> Departmentde ola bilecek maksimum employee sayini gosterir
            - Employees-> bu bir arraydir ve icinde Employee obyektlerini saxlayacaq

            - AddEmployee() -> parametr olaraq bir Employee obyekti qebul edecek eger yuxarida olan Employees arrayin uzunlugu employeeLimiti kecmirse qebul etdiyi Employee obyektini yuxarida olan Employees arrayine elave edecek.
            - GetAllEmployees() -> butun employeeleri geriye qaytaracaq.
            */

            Employee emp1 = new Employee("Murad", 1200);
            Employee emp2 = new Employee("Davud", 1300);
            Employee emp3 = new Employee("Said", 1400);
            
            Department department = new Department("DEP", 15);

            department.AddEmployer(emp1);
            department.AddEmployer(emp2);
            department.GetAllEmployees();
            Console.WriteLine("============");
            department.AddEmployer(emp3);
            department.GetAllEmployees();
        }
    }
}
