namespace MVC_Practice.Exceptions;

public class ItemNotFoundException<T> : Exception
{
    public ItemNotFoundException(string message = $"{nameof(T)} Not Found!") : base(message) { }
}
