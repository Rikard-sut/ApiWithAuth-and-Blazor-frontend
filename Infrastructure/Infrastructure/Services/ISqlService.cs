using Application.Todo;
using Domain.TodoTask;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISqlService
    {
        Task<IEnumerable<DayDto>> GetDaysAsync(GetDaysQuery request);
        Task<DayDto> GetDayAsync(GetDayQuery request);
        Task<bool> AddTodoTaskAsync(AddTodoTaskCommand command);
        Task<bool> UpdateTodoTaskAsync(UpdateTodoTaskCommand command);
        Task<bool> ClearTodoTasksAsync(ClearTodoTasksCommand command);
        Task<bool> CompleteTodoTaskAsync(CompleteTodoTaskCommand command);
    }
}