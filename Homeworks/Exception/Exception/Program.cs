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

            Console.WriteLine("Hello, World!");
        }
    }
}
