using EnsureThat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAINATest.Model;

namespace TAINATest.CommandHandlers
{
    public class AddPerson :IRequest<bool> 
    {
        public PersonDTO PersonDTO { get; set; }

        public AddPerson(PersonDTO personDTO)
        {
            EnsureArg.IsNotNull(personDTO);  
            EnsureArg.IsNotNullOrEmpty(personDTO.FirstName);
            EnsureArg.IsNotNullOrEmpty(personDTO.SurName);
            EnsureArg.IsNotNullOrEmpty(personDTO.PhoneNumber);
            EnsureArg.IsDateTime(personDTO.DateOfBirth);
            PersonDTO = personDTO;
        }
    }
}
