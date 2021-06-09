namespace Domain.TodoTask
{
    public class TodoTaskDto
    {
        public int TodoTaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string Error { get; set; }
    }
}
