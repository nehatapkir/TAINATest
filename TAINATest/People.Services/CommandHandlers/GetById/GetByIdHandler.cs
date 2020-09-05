using EnsureThat;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TAINATest.Model;
using TAINATest.Repository;

namespace TAINATest.CommandHandlers
{
    public class GetByIdHandler : IRequestHandler<GetById, PersonDTO>
    {
        IRepository<Person> _personRepository;
        AutoMapper.IMapper _mapper;


        public GetByIdHandler(IRepository<Person> personRepository, AutoMapper.IMapper mapper)
        {
            EnsureArg.IsNotNull(personRepository);
            EnsureArg.IsNotNull(mapper);
   
            _personRepository = personRepository;
            _mapper = mapper;
         
        }
      
        public  Task<PersonDTO> Handle(GetById getById, CancellationToken cancellationToken)
        {           
           var person =  _personRepository.GetItemById(getById.Id).Result;
            var personDTO = _mapper.Map<Person, PersonDTO>(person);   
            return Task.FromResult(personDTO);
        }
    }
}
