namespace StoreApp.Exceptions
{
    internal class ProductAlreadyExistsException : Exception
    {
        public ProductAlreadyExistsException(string message = "Product Already Exists!") : base(message) { }
    }
}
