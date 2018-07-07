using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasker.Web.Models;

namespace Tasker.Web.DataAccess
{
    public class TaskerDbContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        public TaskerDbContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
