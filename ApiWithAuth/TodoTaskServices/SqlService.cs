using ApiWithAuth.TodoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithAuth
{
    public class SqlService : ISqlService
    {
        private readonly TodoDbContext todoDb;
        public SqlService(TodoDbContext todoDbContext)
        {
            this.todoDb = todoDbContext;
        }
        /// <summary>
        /// Get all days with all their tasks from the db, for the right user.
        /// </summary>
        /// <param name="userName">The specified user we want to get data for</param>
        /// <returns>An array of days</returns>
        public async Task<IEnumerable<Day>> GetDaysAsync(string userName)
        {
            var days = todoDb.Days.Select(x => x).ToArray();
            foreach(var item in days)
            {
                var tasks = todoDb.TodoTasks.Where(x => x.UserName == userName && x.DayId == item.DayId).ToList();
                item.TodoTasks = tasks;
                
            }
            
            return await Task.FromResult(days);
        }
        public async Task<Day> GetDayAsync(string userName, int dayId)
        {
            var day = todoDb.Days.Where(x => x.DayId == dayId).FirstOrDefault();

            var tasks = todoDb.TodoTasks.Where(x => x.UserName == userName && x.DayId == dayId).ToList();
            day.TodoTasks = tasks;
            return await Task.FromResult(day);

        }
        /// <summary>
        /// Adds a todotask to the database
        /// </summary>
        /// <param name="todoTask">the task to add</param>
        /// <returns>a boolean that represents the success or failure of the operation</returns>
        public async Task<bool> AddTodoTaskAsync(TodoTask todoTask)
        {
            await todoDb.TodoTasks.AddAsync(todoTask);
            int response = await todoDb.SaveChangesAsync();
            if(response == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
