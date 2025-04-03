using HWException.Models;

namespace HWException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Meeting class:
            - FromDate
            - ToDate
            - FullName
 
            MeetingSchedule class:
            Meetings - Meeting array-ı
            SetMeeting(fullname,from,to) - gonderilmis deyerlere esasen meeting yaratmaga calisir.
            - Eger Gonderilmis tarix intervalinda meeting varsa geriye ReservedDateInterval exception qaytarir, 
            - eger gonderilen fromdate todate-den kicik deyilse WrongDateInterval exception qaytarir,
            - her sey okaydirse meeting obyekti yaradib meeting listine add edir
            */

            Meeting meeting1 = new Meeting("Murad N", DateTime.Parse("5/25/2025"), DateTime.Parse("5/27/2025"));
            
            MeetingSchedule meetingSchedule = new MeetingSchedule([meeting1]);

            meetingSchedule.SetMeeting("Davud N", DateTime.Parse("5/26/2025"), DateTime.Parse("5/28/2025"));
            meetingSchedule.SetMeeting("Davud N", DateTime.Parse("5/29/2025"), DateTime.Parse("5/28/2025"));
            meetingSchedule.SetMeeting("Said N", DateTime.Parse("5/29/2025"), DateTime.Parse("5/29/2025"));
            meetingSchedule.SetMeeting("Said N", DateTime.Parse("5/29/2025"), DateTime.Parse("5/30/2025"));
            meetingSchedule.SetMeeting("Said N", DateTime.Parse("6/1/2025"), DateTime.Parse("6/2/2025"));
        }
    }
}
