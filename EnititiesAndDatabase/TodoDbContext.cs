using System;
using System.Collections.Generic;
using System.Text;

namespace EnititiesAndDatabase
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() : base(@"data source=LAPTOP-Q58DHVN7;initial catalog=TodoDB;integrated security=True;")
        {

        }
    }
}
