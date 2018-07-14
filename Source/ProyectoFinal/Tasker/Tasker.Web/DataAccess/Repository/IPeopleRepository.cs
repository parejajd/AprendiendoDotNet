using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Web.Models;

namespace Tasker.Web.DataAccess.Repository
{
    public interface IPeopleRepository
    {
        List<Person> Person { get; }
        bool Add(Person person);
        bool Update(int personId, Person updatedPerson);
        bool Delete(int personId);
    }
}
