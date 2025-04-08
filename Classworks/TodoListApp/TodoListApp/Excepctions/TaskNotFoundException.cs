namespace TodoListApp.Excepctions
{
    internal class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(string message = "Task not found!") : base(message) { }
    }
}
