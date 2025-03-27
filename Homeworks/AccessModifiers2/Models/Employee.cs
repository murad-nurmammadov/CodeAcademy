namespace Models
{
    public class Employee
    {
        public string Name { get; set; }
        public bool IsSuccessful { get; set; }
        public float Salary { get; set; }

        public Employee(string name, bool isSuccessful, float salary)
        {
            Name = name;
            IsSuccessful = isSuccessful;
            Salary = salary;
        }

        public override string ToString()
        {
            string successIndicator = IsSuccessful ? "is" : "is not";
            return $"{Name} {successIndicator} successful; {Salary}";
        }
    }
}
