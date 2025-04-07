namespace HospitalProject.Exceptions
{
    internal class AppointmentOverlapException : Exception
    {
        public AppointmentOverlapException(string message = "Overlaps with another appointment!") : base(message) { }
    }
}
