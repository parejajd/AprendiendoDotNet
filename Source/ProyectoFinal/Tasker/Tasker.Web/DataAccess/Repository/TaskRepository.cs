﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Web.Models;

namespace Tasker.Web.DataAccess.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskerDbContext Context;

        public TaskRepository(TaskerDbContext context)  
        {
            this.Context = context;
        }

        public List<MyTask> Tasks { get => this.Context.Tasks.ToList(); }

        public bool Add(MyTask task)
        {
            this.Context.Tasks.Add(task);

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