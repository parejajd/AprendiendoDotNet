using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Web.Models;

namespace Tasker.Web.DataAccess.Repository
{
    public interface ITaskRepository
    {
        List<MyTask> Tasks { get; }

        bool Add(MyTask task);

        bool Update(int taskId, MyTask updatedTask);

        bool Delete(int taskId);
    }
}
