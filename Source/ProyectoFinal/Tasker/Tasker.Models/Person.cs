using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasker.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

         public string Email { get; set; }
         public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }

        public IEnumerable<MyTask> CreatedByMe { get; set; }

        public IEnumerable<PersonTasks> AssignedToMe { get; set; }
    }
}
