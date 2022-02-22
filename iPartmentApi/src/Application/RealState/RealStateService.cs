using API.src.Domain.RealState.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Application
{
    public class RealStateService
    {
         private readonly IRealStateRepository _repository;

       public RealStateService(IRealStateRepository repo) {
            _repository = repo;
        }


        // public RealStateService(BuildContext context) { 

        // }

        // public async bool alreadyExists(RealState obj) { 


        // }

    }
}
