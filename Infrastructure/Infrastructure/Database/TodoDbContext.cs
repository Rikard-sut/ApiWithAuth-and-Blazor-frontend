using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<Day> Days { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Day>().HasData(
                new Day { DayId = 1, NameOfDay = "Monday" },
                new Day { DayId = 2, NameOfDay = "Tuesday" },
                new Day { DayId = 3, NameOfDay = "Wednesday" },
                new Day { DayId = 4, NameOfDay = "Thursday" },
                new Day { DayId = 5, NameOfDay = "Friday" },
                new Day { DayId = 6, NameOfDay = "Saturday" },
                new Day { DayId = 7, NameOfDay = "Sunday" });
        }
    }
}
