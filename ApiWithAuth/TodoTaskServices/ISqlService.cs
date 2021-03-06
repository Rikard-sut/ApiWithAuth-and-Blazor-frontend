﻿using ApiWithAuth.TodoDbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithAuth
{
    public interface ISqlService
    {
        Task<IEnumerable<Day>> GetDaysAsync(string userName);
        Task<Day> GetDayAsync(string userName, int dayId);
        Task<bool> AddTodoTaskAsync(TodoTask todoTask);
    }
}