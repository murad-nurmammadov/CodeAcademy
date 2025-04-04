namespace StoreApp.Exceptions
{
    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message = "Product Not Found!") : base(message) { }
    }
}

