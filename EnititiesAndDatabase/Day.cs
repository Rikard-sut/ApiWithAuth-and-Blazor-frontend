using System;

namespace EnititiesAndDatabase
{
    public class Day
    {
        public int DayId { get; set; }
        public string NameOfDay { get; set; }
        public int TodoTaskId { get; set; }
        public ICollection<TodoTask> Tasks { get; set; }
    }
}
