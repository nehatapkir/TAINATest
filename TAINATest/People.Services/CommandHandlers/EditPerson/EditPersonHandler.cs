using EnsureThat;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TAINATest.Configurations;
using TAINATest.Model;
using TAINATest.Repository;

namespace TAINATest.CommandHandlers
{
    public class EditPersonHandler : IRequestHandler<EditPerson, bool>
    {
        IRepository<Person> _personRepository;
        AutoMapper.IMapper _mapper;

        public EditPersonHandler(IRepository<Person> personRepository, AutoMapper.IMapper mapper)
        {
            EnsureArg.IsNotNull(personRepository);
            EnsureArg.IsNotNull(mapper);
       
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public  Task<bool> Handle(EditPerson editPerson, CancellationToken cancellationToken)
        {          
            var person = _mapper.Map<PersonDTO, Person>(editPerson.PersonDTO);
            _personRepository.UpdateItem(person);
            return Task.FromResult(true);
        }
    }
}
