using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TodoTask
{
    public class GetDaysResponse
    {
        public string Error { get; set; }
        public IEnumerable<DayDto> Days { get; set; }
    }
}
