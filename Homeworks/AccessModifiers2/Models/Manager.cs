namespace Models
{
    public class Manager
    {
        protected static Employee GetPromotion(Employee emp)
        {
            emp.Salary += 100;
            return emp;
        }
    }
}
