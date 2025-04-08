namespace TodoListApp.Models
{
    internal class TaskItem : TaskBase
    {
        public TaskItem(string title) : base(title) { }

        public override void Print()
        {
            string status = IsCompleted ? "Completed" : "Not Completed";
            Console.WriteLine($"{Id}. {Title} | {status}");
        }
    }
}
