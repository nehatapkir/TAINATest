using Infrastructure.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAINATest.Configurations;
using TAINATest.Model;

namespace TAINATest.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        
        private PersonDbContext _personDbContext;
        private ILogger _logger;
        public PersonRepository(PersonDbContext personDbContext, ILogger<PersonRepository> logger)
        {
            _personDbContext = personDbContext;
            _logger = logger;
        }

        public  void AddItem(Person item)
        {
            try
            {
                var person = new Person()
                {
                    SurName = item.SurName,
                    FirstName = item.FirstName,
                    EmailAddress = item.EmailAddress,
                    Gender = item.Gender,
                    DateOfBirth = item.DateOfBirth,
                    PhoneNumber = item.PhoneNumber
                };
                 _personDbContext.Add(person);
                 _personDbContext.SaveChanges();
                _logger.LogInformation($"Successfully created item with  with  name {item.FirstName} {item.SurName}");
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occured while adding item with  name {item.FirstName} {item.SurName} . Exception details :{ex.Message}");
            }
        }


        public async Task<Person> GetItemById(long id)
        {
            try
            {
                var item = await _personDbContext.People.FindAsync(id);
                _logger.LogInformation($"Successfully fetched item with id : {id}");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching item with Id {id}. Exception details :{ex.Message}");
            }
            return null;
        }

        public IEnumerable<Person> GetAllItems()
        {
            try
            {
                var details = _personDbContext.People;
                _logger.LogInformation($"Successfully fetched all data");
                return details;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching items. Exception details :{ex.Message}");
            }
            return null;
        }

        public async Task UpdateItem(Person item)
        {
            try
            {
                var personToUpdate = _personDbContext.People
              .Where(p => p.PersonId == item.PersonId).FirstOrDefault();

                if (personToUpdate != null)
                {
                    _personDbContext.Entry(personToUpdate).CurrentValues.SetValues(item);
                }

                await _personDbContext.SaveChangesAsync();
                _logger.LogInformation($"Updated details for item with id {item.PersonId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while updating item with Id {item.PersonId}. Exception details :{ex.Message}");
            }         

        }
    }
}
