namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public DateTime DateCompleted { get; set; }

    }
}
