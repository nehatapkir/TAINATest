using AutoMapper;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAINATest.ProfileMapping;

namespace TAINATest.Configurations
{
    public class AutoMapperConfiguration
    {
        public IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonProfileMapping>();
            });

            IMapper mapper = config.CreateMapper();        
    
            return mapper;
        }
    }
}
