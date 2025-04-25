namespace PizzaMizzaApp.Exceptions;

internal class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message = "Product Nof Found!") : base(message) { }
}
