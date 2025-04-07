namespace HospitalProject.Exceptions
{
    internal class EndBeforeStartException : Exception
    {
        public EndBeforeStartException(string message = "End date cannot be before start date!") : base(message) { }
    }
}
