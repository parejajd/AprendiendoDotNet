using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasker.Web.Models
{
    public class MyTask
    {
        public int MyTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int CreatedById { get; set; }
        public Person CreatedBy { get; set; }

        public IEnumerable<PersonTasks> AssignedPerson { get; set; }
    }
}
