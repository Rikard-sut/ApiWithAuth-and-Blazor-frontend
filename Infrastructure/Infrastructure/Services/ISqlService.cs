using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISqlService
    {
        Task<IEnumerable<DayDto>> GetDaysAsync(GetDaysQuery request);
        Task<DayDto> GetDayAsync(GetDayQuery request);
        Task<bool> AddTodoTaskAsync(AddTodoTaskQuery request);
    }
}