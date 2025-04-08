using TodoListApp.Excepctions;

namespace TodoListApp.Models
{
    static internal class TaskManager
    {
        // Fields
        static private TaskItem[] _tasks = [];

        // Properties
        static public TaskItem[] Tasks
        {
            get => _tasks;
            set => _tasks = value;
        }

        // Methods
        static public void AddTask(TaskItem task)
        {
            Array.Resize(ref _tasks, Tasks.Length + 1);
            Tasks[^1] = task;
        }

        static public void ShowTasks()
        {
            foreach (TaskItem task in Tasks) { task.Print(); }
        }

        static public void CompleteTask(int id)
        {
            foreach (var task in Tasks)
            {
                if (task.Id == id)
                {
                    task.IsCompleted = true;
                }
            }
        }

        static public void DeleteTask(int id)
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i].Id == id)
                {
                    Tasks[i] = Tasks[^1];
                    Array.Resize(ref _tasks, Tasks.Length - 1);
                    return;
                }
            }

            throw new TaskNotFoundException();
        }
    }
}
