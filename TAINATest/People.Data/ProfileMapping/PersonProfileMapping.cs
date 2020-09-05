using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAINATest.Model;

namespace TAINATest.ProfileMapping
{
    public class PersonProfileMapping :Profile
    {
        public PersonProfileMapping()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
