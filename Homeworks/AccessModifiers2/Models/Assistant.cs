namespace Models
{
    public class Assistant : Manager
    {
        public void GiveFeedback(Employee emp)
        {            
            if (emp.IsSuccessful)
            {
                GetPromotion(emp);
            }
        }
    }
}
