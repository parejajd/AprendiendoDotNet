using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;

namespace Tasker.Services
{
    public interface IPeopleRepository
    {
        List<Person> Person { get; }
        bool Add(Person person);
        bool Update(int personId, Person updatedPerson);
        bool Delete(int personId);
    }
}
