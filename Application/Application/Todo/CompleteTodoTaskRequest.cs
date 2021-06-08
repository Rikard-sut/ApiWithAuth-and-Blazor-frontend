using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo
{
    public class UpdateTodoTaskRequest
    {
        public int TodoTaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
