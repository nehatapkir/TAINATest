
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TAINATest.CommandHandlers;

using TAINATest.Model;

namespace TAINATest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;       

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public IActionResult Get()
        {
            var getAllPersonsRequest = new GetAllPersons();
            var results =  _mediator.Send(getAllPersonsRequest, default);
            if(results.Result == null)
            {
                return NotFound();
            }
            return Ok(results.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(long id)
        {
            var getAllPersonsRequest = new GetById(id);
            var results = _mediator.Send(getAllPersonsRequest, default);
            if (results.Result == null)
            {
                return NotFound();
            }
            return Ok(results.Result);
        }

        // POST api/values
        [HttpPost]
        public Task<bool> Post([FromBody] PersonDTO personDTO)
        {
            var addPersonRequest = new AddPerson(personDTO);
            var results = _mediator.Send(addPersonRequest, default);
            return results;
        }

  
        [HttpPut]
        public Task<bool> Put([FromBody] PersonDTO personDTO)
        {
            var editPersonRequest = new EditPerson(personDTO);
            var results = _mediator.Send(editPersonRequest, default);
            return results;
        }

    }
}
