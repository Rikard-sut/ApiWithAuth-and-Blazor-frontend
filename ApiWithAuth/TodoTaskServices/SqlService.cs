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
        public async Task<IEnumerable<Day>> GetDaysAsync(string userName)
        {
            var response = todoDb.Days.Select(x => x).ToArray();
            foreach(var item in response)
            {
                var tasks = todoDb.TodoTasks.Where(x => x.UserName == userName && x.DayId == item.DayId).ToList();
                item.TodoTasks = tasks;
                
            }
            
            return await Task.FromResult(response);
        }
    }
}
