namespace QuizApp.Exceptions
{
    internal class QuizNotFoundException : Exception
    {
        public QuizNotFoundException(string message = "Quiz Not Found!") : base(message) { }
    }
}
