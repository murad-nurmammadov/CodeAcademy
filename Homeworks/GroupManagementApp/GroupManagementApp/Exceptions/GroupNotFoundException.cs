namespace GroupManagementApp.Exceptions
{
    internal class GroupNotFoundException : Exception
    {
        public GroupNotFoundException(string message = "Group Not Found!") : base(message) { }
    }
}
