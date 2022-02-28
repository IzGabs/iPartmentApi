using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Domain.Condominium;
using API.src.Domain.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Core.Errors;

namespace API.src.Application.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository repository;
        private readonly ILocationService locationService;

        public CondominiumService(ICondominiumRepository repository, ILocationService locationService) { 
            this.repository = repository;
            this.locationService = locationService;
        } 
        
        public async Task<bool> Create(CondominiumObject obj)
        {
            Address _newLocation = await locationService.Create(obj.Location);
            obj.Location = _newLocation ?? throw new CouldNotCreateLocationException();

            var request = await repository.Create(obj);
            if (request != null) return true;
            return false; 
        }

        public async Task<CondominiumObject> Get(int id) => await repository.Get(id);

        public async Task<List<CondominiumObject>> GetAll() => await repository.GetAll();

        public async Task<List<RealStateObject>> realStatesFromCondominium(int id)
        {
            throw new NotImplementedException();
        }
    }
}
