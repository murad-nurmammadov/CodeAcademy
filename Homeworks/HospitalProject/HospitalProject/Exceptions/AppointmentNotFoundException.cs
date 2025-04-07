namespace HospitalProject.Exceptions
{
    internal class AppointmentNotFoundException : Exception
    {
        public AppointmentNotFoundException(string message = "Apppointment Not Found!") : base(message) { }
    }
}
