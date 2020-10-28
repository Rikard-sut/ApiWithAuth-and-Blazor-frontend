using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
        public class Day
        {
            public int DayId { get; set; }
            public string NameOfDay { get; set; }
            public List<TodoTask> TodoTasks { get; set; }
        }
    
}
