using HWException.Exceptions;

namespace HWException.Models
{
    public class MeetingSchedule
    {
        public Meeting[] Meetings { get; set; }

        public void SetMeeting(string fullName, DateTime fromDate, DateTime toDate)
        {
            Meeting newMeeeting = new Meeting(fullName, fromDate, toDate);

            if (fromDate >= toDate)
            {
                //Array.Sort();
                foreach(Meeting meeting in Meetings)
                {
                    
                }

                throw new ReservedDateIntervalException("");
            }
            else if (fromDate >= toDate)
            {
                throw new WrongDateIntervalException("");
            }
            else
            {
                //Array.Resize(ref Meetings, Meetings.Length + 1);
            }
        }
    }
}
