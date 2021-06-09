using System.Collections.Generic;

namespace Infrastructure.Database.Entities
{
    public class Day
    {
        public int DayId { get; set; }
        public string NameOfDay { get; set; }
        public ICollection<TodoTask> TodoTasks { get; set; }
    }
}
