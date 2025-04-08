namespace TodoListApp.Models
{
    abstract internal class TaskBase
    {
        // Fields
        protected static int _id = 0;

        // Properties
        public int Id { get; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        // Constructor
        protected TaskBase(string title)
        {
            Id = ++_id;
            if (string.IsNullOrWhiteSpace(title)) { Title = "New Task"; }
            else { Title = title; }
            IsCompleted = false;
        }

        // Abstract Methods
        abstract public void Print();
    }
}
