using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TodoTask
{
    public class DayDto
    {
        public int DayId { get; set; }
        public string NameOfDay { get; set; }
        public IEnumerable<TodoTaskDto> TodoTasks { get; set; }
    }
}
