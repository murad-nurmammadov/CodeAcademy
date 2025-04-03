using HWException.Exceptions;

namespace HWException.Models
{
    public class MeetingSchedule
    {
        // Fields
        private Meeting[] _meetings;
        
        // Methods
        public Meeting[] Meetings { get => _meetings; set => _meetings = value; }

        // Constructors
        public MeetingSchedule(Meeting[] meetings)
        {
            Meetings = meetings;
        }

        // Methods
        public void SetMeeting(string fullName, DateTime fromDate, DateTime toDate)
        {
            Meeting plannedMeeeting = new Meeting(fullName, fromDate, toDate);

            try
            {
                // Checks if the start or the end of the planned meeting coincides with another meeting
                foreach (Meeting meeting in Meetings)
                {
                    if ((meeting.FromDate <= plannedMeeeting.FromDate
                        && plannedMeeeting.FromDate <= meeting.ToDate)
                        ||
                        (meeting.FromDate <= plannedMeeeting.ToDate
                        && plannedMeeeting.ToDate <= meeting.ToDate))
                    {
                        throw new ReservedDateIntervalException("Coincides with another meeting!");
                    }
                }

                // Check if end is before start or if they coincde
                if (fromDate > toDate)
                {
                    throw new WrongDateIntervalException("Meeting cannot end before it starts!");
                }
                else if (fromDate == toDate)
                {
                    throw new WrongDateIntervalException("Start and end cannot coincide!.");
                }


                // Add meeting
                else
                {
                    Array.Resize(ref _meetings, Meetings.Length + 1);
                    _meetings[^1] = plannedMeeeting;
                    Console.WriteLine($"Meeting with {fullName} from {fromDate} to {toDate} is added!");
                }
            }
            catch (ReservedDateIntervalException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (WrongDateIntervalException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
