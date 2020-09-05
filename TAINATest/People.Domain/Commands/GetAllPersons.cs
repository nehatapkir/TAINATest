using EnsureThat;
using MediatR;
using System.Collections.Generic;
using TAINATest.Model;

namespace TAINATest.CommandHandlers
{
    public class GetAllPersons :IRequest<IEnumerable<PersonDTO>> 
    {       
        
    }
}
