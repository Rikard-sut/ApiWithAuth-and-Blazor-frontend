using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Database;
using Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SqlService : ISqlService
    {
        private readonly TodoDbContext _todoDb;

        public SqlService(TodoDbContext todoDbContext)
        {
            _todoDb = todoDbContext;
        }

        public async Task<IEnumerable<DayDto>> GetDaysAsync(GetDaysQuery request)
        {
            var days = _todoDb.Days.Select(x => x).ToArray();

            if (days == null)
                return null;

            List<DayDto> dayDtos = new List<DayDto>();

            foreach (var item in days)
            {
                var dayDto = new DayDto { DayId = item.DayId, NameOfDay = item.NameOfDay };
                var todoTasksForday = _todoDb.TodoTasks.Where(x => x.UserName == request.GetDaysOnUserName && x.DayId == item.DayId).ToList();

                dayDto.TodoTasks = CreateTodoTaskDtos(todoTasksForday);
                dayDtos.Add(dayDto);
            }

            return await Task.FromResult(dayDtos);
        }

        public async Task<DayDto> GetDayAsync(GetDayQuery request)
        {
            var day = _todoDb.Days.Where(x => x.DayId == request.DayId).FirstOrDefault();

            if (day == null)
                return null;

            var dayDto = new DayDto { DayId = day.DayId, NameOfDay = day.NameOfDay };

            day.TodoTasks = _todoDb.TodoTasks.Where(x => x.UserName == request.GetDayOnUsername && x.DayId == request.DayId).ToList();

            dayDto.TodoTasks = CreateTodoTaskDtos(day.TodoTasks.ToList());

            return await Task.FromResult(dayDto);

        }

        public async Task<bool> AddTodoTaskAsync(AddTodoTaskQuery request)
        {
            var todoTask = CreateTodoTask(request);
            await _todoDb.TodoTasks.AddAsync(todoTask);
            int response = await _todoDb.SaveChangesAsync();

            return response != 0;
        }

        public async Task<bool> UpdateTodoTaskAsync(UpdateTodoTaskQuery request)
        {
            var todoTask = _todoDb.TodoTasks.Where(x => x.TodoTaskId == request.TodoTaskId).FirstOrDefault();
            todoTask.Description = request.Description;
            todoTask.IsCompleted = request.IsCompleted;

            int response = await _todoDb.SaveChangesAsync();

            return response != 0;
        }

        public async Task<bool> ClearTodoTasksAsync(ClearTodoTasksQuery request)
        {
            var todoTasks = _todoDb.TodoTasks.Where(x => x.UserName == request.ClearTasksForUsername);
            _todoDb.TodoTasks.RemoveRange(todoTasks);

            int response = await _todoDb.SaveChangesAsync();

            return response != 0;
        }

        private static TodoTask CreateTodoTask(AddTodoTaskQuery request)
        {
            return new TodoTask { DayId = request.DayId, Description = request.Description, IsCompleted = request.IsCompleted, UserName = request.AddTodoTaskOnUsername };
        }

        private List<TodoTaskDto> CreateTodoTaskDtos(List<TodoTask> todoTasksForday)
        {
            List<TodoTaskDto> todoTaskDtos = new List<TodoTaskDto>();
            foreach (var task in todoTasksForday)
            {
                var todoTaskDto = new TodoTaskDto { Description = task.Description, IsCompleted = task.IsCompleted, TodoTaskId = task.TodoTaskId };
                todoTaskDtos.Add(todoTaskDto);
            }
            return todoTaskDtos;
        }
    }
}
