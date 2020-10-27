using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BackendDBandEntities
{
    class TodoDbContext : DbContext
    {
        string connectionString = @"data source=LAPTOP-Q58DHVN7;initial catalog=TodoDB;integrated security=True;";
        public TodoDbContext(string connectionString) : base(GetOptions(connectionString))
        {

        }
        public DbSet<Day> Days { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
