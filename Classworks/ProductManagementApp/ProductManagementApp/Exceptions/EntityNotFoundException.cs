namespace ProductManagementApp.Exceptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message = "Entity not found!") : base(message) { }
    }
}
