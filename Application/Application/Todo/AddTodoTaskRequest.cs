using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo
{
    public class AddTodoTaskRequest
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int DayId { get; set; }
    }
}
