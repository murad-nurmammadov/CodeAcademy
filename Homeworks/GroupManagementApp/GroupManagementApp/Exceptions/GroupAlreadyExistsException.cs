namespace GroupManagementApp.Exceptions
{
    internal class GroupAlreadyExistsException : Exception
    {
        public GroupAlreadyExistsException(string message = "Group Already Exists!") : base(message) { }
    }
}
