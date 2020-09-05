using EnsureThat;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TAINATest.Model;
using TAINATest.Repository;

namespace TAINATest.CommandHandlers
{
    public class AddPersonHandler : IRequestHandler<AddPerson, bool>
    {
        IRepository<Person> _personRepository;
        AutoMapper.IMapper _mapper;

        public AddPersonHandler(IRepository<Person> personRepository, AutoMapper.IMapper mapper)
        {
            EnsureArg.IsNotNull(personRepository);
            EnsureArg.IsNotNull(mapper);
          
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public  Task<bool> Handle(AddPerson addPerson, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<PersonDTO, Person>(addPerson.PersonDTO);
             _personRepository.AddItem(person);
            return Task.FromResult(true);
        }
    }
}
