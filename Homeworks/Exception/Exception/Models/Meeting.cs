namespace HWException.Models
{
    public class Meeting
    {
        public string FullName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Meeting(string fullName, DateTime fromDate, DateTime toDate)
        {
            FullName = fullName;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
