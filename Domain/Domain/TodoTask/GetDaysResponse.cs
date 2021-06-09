using System.Collections.Generic;

namespace Domain.TodoTask
{
    public class GetDaysResponse
    {
        public string Error { get; set; }
        public IEnumerable<DayDto> Days { get; set; }
    }
}
