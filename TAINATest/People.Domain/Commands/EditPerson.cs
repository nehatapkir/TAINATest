using EnsureThat;
using MediatR;
using TAINATest.Model;

namespace TAINATest.CommandHandlers
{
    public class EditPerson :IRequest<bool> 
    {
        public PersonDTO PersonDTO;

        public EditPerson(PersonDTO person)
        {
            EnsureArg.IsNotNull(person);
            EnsureArg.IsTrue(person.PersonId > 0);
            EnsureArg.IsNotNullOrEmpty(person.FirstName);
            EnsureArg.IsNotNullOrEmpty(person.SurName);
            EnsureArg.IsNotNullOrEmpty(person.PhoneNumber);
            EnsureArg.IsDateTime(person.DateOfBirth);
            PersonDTO = person;
        }
    }
}
