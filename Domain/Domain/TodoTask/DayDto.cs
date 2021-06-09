using System.Collections.Generic;

namespace Domain.TodoTask
{
    public class DayDto
    {
        public int DayId { get; set; }
        public string NameOfDay { get; set; }
        public IEnumerable<TodoTaskDto> TodoTasks { get; set; }
    }
}
