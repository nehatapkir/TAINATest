using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAINATest.Model;
using TAINATest.Repository;

namespace PeopleAPITest
{
    internal class TestPersonRepository : IRepository<Person>
    {
        List<Person> personList;
        public TestPersonRepository()
        {
            personList = new List<Person>();
            personList.Add(new Person() { PersonId = 1, FirstName = "Neha", SurName = "Tapkir", DateOfBirth = new DateTime(), EmailAddress = "drandom@random.com", Gender = 1, PhoneNumber = "000000000" });
            personList.Add(new Person() { PersonId = 2, FirstName = "Saurabh", SurName = "Sonparote", DateOfBirth = new DateTime(), EmailAddress = "pppp@random.com", Gender = 2, PhoneNumber = "000000001" });
        }
        public void AddItem(Person item)
        {
            personList.Add(item);
        }

        public IEnumerable<Person> GetAllItems()
        {
            return personList;
        }

        public Task<Person> GetItemById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Person item)
        {
            personList.Add(item);
            return Task.FromResult(true);
        }
    }
}
