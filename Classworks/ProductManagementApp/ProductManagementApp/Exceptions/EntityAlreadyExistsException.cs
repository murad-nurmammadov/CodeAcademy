namespace ProductManagementApp.Exceptions
{
    internal class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message = "Entity with this id already exists!") : base(message) { }
    }
}
