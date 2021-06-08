using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TodoTask
{
    public class TodoTaskDto
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string Error { get; set; }
    }
}
