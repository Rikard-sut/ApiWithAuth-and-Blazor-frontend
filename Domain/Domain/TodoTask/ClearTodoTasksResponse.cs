using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TodoTask
{
    public class ClearTodoTasksResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
