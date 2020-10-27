using System;
using System.Collections.Generic;
using System.Text;

namespace EnititiesAndDatabase
{
    class TodoTask
    {
        public int TodoTaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string UserName { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}
