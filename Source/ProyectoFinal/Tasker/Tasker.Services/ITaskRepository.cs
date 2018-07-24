using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Services
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
