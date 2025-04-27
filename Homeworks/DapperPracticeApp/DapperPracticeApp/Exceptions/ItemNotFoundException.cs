namespace DapperPracticeApp.Exceptions;

internal class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message = "Item Not Found!") 
        : base(message) { }
}
