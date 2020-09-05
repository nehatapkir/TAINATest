using EnsureThat;
using MediatR;
using System.Collections.Generic;
using TAINATest.Model;

namespace TAINATest.CommandHandlers
{
    public class GetById :IRequest<PersonDTO> 
    {       
        public long Id { get; set; }
        public GetById(long Id)
        {
            EnsureArg.IsTrue(Id > 0);
            this.Id = Id;
        }
    }
}
