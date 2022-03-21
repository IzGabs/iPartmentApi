using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Domain.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Core.Errors;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Condominium;
using API.src.Domain.Values;

namespace API.src.Application.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository repository;
        private readonly ILocationService locationService;
        private readonly IMonetaryService<CondominiumMonetary> condoMonetaryService;

        public CondominiumService(ICondominiumRepository repository, ILocationService locationService, IMonetaryService<CondominiumMonetary> condoMonetaryService) { 
            this.repository = repository;
            this.locationService = locationService;
            this.condoMonetaryService = condoMonetaryService;
        } 
        
        public async Task<CondominiumObject> Create(CondominiumObject obj)
        {
            Address _newLocation = await locationService.Create(obj.Location);
            obj.Location = _newLocation ?? throw new CouldNotCreateLocationException();

            var regMonetaryValues = await condoMonetaryService.Create(obj.Valores);
            obj.Valores = regMonetaryValues ?? throw CouldNotCreateCondoValues.Default();

            var request = await repository.Create(obj);
            return request;
        }

        public async Task<CondominiumObject> Get(int id) => await repository.Get(id);

        public async Task<List<CondominiumObject>> GetAll() => await repository.GetAll();

    }
}
