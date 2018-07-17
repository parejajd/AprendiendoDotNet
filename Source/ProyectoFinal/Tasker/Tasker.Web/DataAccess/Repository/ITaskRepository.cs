﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Web.Models;

namespace Tasker.Web.DataAccess.Repository
{
    public interface ITaskRepository
    {
        List<Project> Projects { get; }

        List<MyTask> Tasks { get; }

        bool Add(MyTask task);

        bool AddProject(Project project);

        bool Update(int taskId, MyTask updatedTask);

        bool Delete(int taskId);
    }
}
