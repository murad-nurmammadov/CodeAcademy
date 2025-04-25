namespace DapperPractice.Models;

internal class TodoItem
{
    public int Id { get; init; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TodoItem(int id, string title, bool isCompleted) { }
}
