using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasker.Models
{
    public class PersonTasks
    {
        public int MyTaskId { get; set; }
        public int PersonId { get; set; }
        public MyTask MyTask { get; set; }
        public Person  Person { get; set; }
    }
}
