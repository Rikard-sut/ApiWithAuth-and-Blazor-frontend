using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithAuth.TodoDbEntities
{
    public class Day
    {
        public int DayId { get; set; }
        public string NameOfDay { get; set; }
        public ICollection<TodoTask> TodoTasks { get; set; }
    }
}
