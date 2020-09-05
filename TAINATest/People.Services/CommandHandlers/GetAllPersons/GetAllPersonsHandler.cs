using EnsureThat;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TAINATest.Model;
using TAINATest.Repository;

namespace TAINATest.CommandHandlers
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersons, IEnumerable<PersonDTO>>
    {
        IRepository<Person> _personRepository;
        AutoMapper.IMapper _mapper;        

        public GetAllPersonsHandler(IRepository<Person> personRepository, AutoMapper.IMapper mapper)
        {
            EnsureArg.IsNotNull(personRepository);
            EnsureArg.IsNotNull(mapper);

            _personRepository = personRepository;
            _mapper = mapper;       
        }
      
        public  Task<IEnumerable<PersonDTO>> Handle(GetAllPersons getAllPersons, CancellationToken cancellationToken)
        {          
             var personsList = _personRepository.GetAllItems().ToList();
                var personDTOList = personsList.Select(a => _mapper.Map<Person, PersonDTO>(a));
                return Task.FromResult(personDTOList);
          
        }
    }
}
