using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Web.ViewModels
{
    public class TasksListViewModel
    {
        public Project CurrentProject { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
}
