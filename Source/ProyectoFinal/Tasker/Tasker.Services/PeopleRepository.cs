using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;
using Tasker.DataAccess;

namespace Tasker.Services
{
    public class PeopleRepository : BaseRepository, IPeopleRepository
    {
        public PeopleRepository(TaskerDbContext context) : base(context)
        {

        }

        public List<Person> Person => this.Context.Person.ToList();

        public bool Add(Person person)
        {
            Context.Person.Add(person);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int personId)
        {
            var oldPerson = this.Context.Person.FirstOrDefault(x => x.PersonId == personId);
            Context.Person.Remove(oldPerson);

            return Context.SaveChanges() > 0;
        }

        public bool Update(int personId, Person updatedPerson)
        {
            var oldPerson = this.Context.Person.FirstOrDefault(x => x.PersonId == personId);
            oldPerson.FirstName = updatedPerson.FirstName;
            oldPerson.LastName = updatedPerson.LastName;
            oldPerson.PhoneNumber = updatedPerson.PhoneNumber;
            oldPerson.Email = updatedPerson.Email;
            oldPerson.Address = updatedPerson.Address;
            oldPerson.BirthDay = updatedPerson.BirthDay;

            return Context.SaveChanges() > 0;
        }
    }
}
