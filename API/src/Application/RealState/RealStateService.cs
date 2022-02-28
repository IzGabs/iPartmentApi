using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Domain.Location;
using API.src.Domain.RealState;
using API.src.Domain.RealState.repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public class RealStateService : IRealStateService
    {
        private readonly IRealStateRepository _repository;
        private readonly ILocationService locationService; 

        public RealStateService(IRealStateRepository repo, ILocationService _locationService)
        {
            _repository = repo;
            locationService = _locationService;
        }

        public async Task<RealStateObject> Create(RealStateObject body)
        {
            Address _newLocation = await locationService.Create(body.localizacao);
            if (_newLocation == null) return null; 

            body.localizacao = _newLocation;
            return await _repository.Create(body);
        }

        public async Task<bool> Delete(RealStateObject body) => await _repository.Delete(body);

        public async Task<List<RealStateObject>> GetList() => await _repository.Getall();

        public async Task<bool> Update(RealStateObject body) => await _repository.Update(body);

        public async Task<RealStateObject> GetByID(int id) => await _repository.Get(id);
    }
}
