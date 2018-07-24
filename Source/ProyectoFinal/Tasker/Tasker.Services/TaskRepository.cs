using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;
using Tasker.DataAccess;

namespace Tasker.Services
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(TaskerDbContext context) : base(context)
        {
        }

        public List<MyTask> Tasks
        {
            get => this.Context.Tasks
                                .Include(x => x.Project)
                                .Include(x => x.CreatedBy)
                                .Include(x => x.AssignedPerson).ThenInclude(y => y.Person).ToList();
        }

        public List<Project> Projects
        {
            get => this.Context.Projects.Include(x => x.Tasks).ToList();
        }

        public bool Add(MyTask task)
        {
            this.Context.Tasks.Add(task);

            return this.Context.SaveChanges() > 0;
        }

        public bool AddProject(Project project)
        {
            this.Context.Projects.Add(project);
            return this.Context.SaveChanges() > 0;
        }

        public bool Delete(int taskId)
        {
            var deletingTask = this.Context.Tasks.FirstOrDefault(x => x.MyTaskId == taskId);

            this.Context.Tasks.Remove(deletingTask);

            return this.Context.SaveChanges() > 0;
        }

        public bool Update(int taskId, MyTask updatedTask)
        {
            var oldTask = Context.Tasks.FirstOrDefault(x => x.MyTaskId == taskId);

            //Solo voy a cambiar el nombre, ustedes pueden cambiar lo demas
            oldTask.Name = updatedTask.Name;
            oldTask.Description = updatedTask.Description;
            oldTask.DueDate = updatedTask.DueDate;
            oldTask.IsCompleted = updatedTask.IsCompleted;

            if (updatedTask.IsCompleted)
            {
                oldTask.CompletedDate = DateTime.Now;
            }

            oldTask.ModificationDate = DateTime.Now;

            return this.Context.SaveChanges() > 0;
        }
    }
}
