using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using TAINATest.CommandHandlers;
using TAINATest.Model;
using TAINATest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using TAINATest.Controllers;
using System;

namespace PeopleAPITest
{
    public class PeopleAPITest
    {
        IRepository<Person> personRepository;

        [SetUp]
        
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IRepository<Person>, TestPersonRepository>();

            var serviceProvider = services.BuildServiceProvider();

            personRepository = serviceProvider.GetService<IRepository<Person>>();
        }

        [Test]
        public async Task TestHandler_GetAllPersonsHandler_ReturnsAllPeopleData()
        {
            var mapper = new Mock<AutoMapper.IMapper>();
            var getAllPersons = new GetAllPersonsHandler(personRepository, mapper.Object);
            var result =  await getAllPersons.Handle(new GetAllPersons(), default);

            Assert.NotNull(result);
            Assert.IsTrue(result.ToList().Count() == 2);
        }
        [Test]
        public void TestHandler_AddPersonHandler_ReturnsTrueWhenSuccessful()
        {
            var mediator = new Mock<IMediator>();

            var mapper = new Mock<AutoMapper.IMapper>();
            var getAllPersons = new AddPersonHandler(personRepository, mapper.Object);
            var dto = new PersonDTO() { PersonId = 1, FirstName = "Neha", SurName = "Tapkir", DateOfBirth = new DateTime(), EmailAddress = "drandom@random.com", Gender = 1, PhoneNumber = "000000000" };
            var result = getAllPersons.Handle(new AddPerson(dto), default);

            Assert.IsTrue(result.Result);
        }

        [Test]
        public  void TestController_GetSpecificPerson_ReturnsNotFoundWhenUnsuccessful()
        {
            var mediator = new Mock<IMediator>();

            var sut = new PersonController(mediator.Object);

            var result =  sut.GetByID(300);

            Assert.IsTrue(result is NotFoundResult);
        }
    }
}
