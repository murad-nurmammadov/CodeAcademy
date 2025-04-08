namespace CustomList.Exceptions
{
    internal class IndexNotFoundException : Exception
    {
        public IndexNotFoundException(string message = "Index Not Found!") : base(message) { }
    }
}
