using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasker.Models; //Cambiado

namespace Tasker.DataAccess //Cambiado
{
    public class TaskerDbContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonTasks> PersonTasks{ get; set; }

        public TaskerDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApi
            modelBuilder.Entity<PersonTasks>()
                .HasKey(key => new { key.MyTaskId, key.PersonId })
                .HasName("PK_PersonTasks");
        }
    }
}
