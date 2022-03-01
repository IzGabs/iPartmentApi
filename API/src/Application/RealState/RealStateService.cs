using API.Domain.Location;
using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Location;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public class RealStateService : IRealStateService<RealStateObject>
    {
        private readonly IRealStateRepository<RealStateObject> _repository;
        private readonly ILocationService locationService;
        private readonly ICondominiumService condominiumService;

        public RealStateService(IRealStateRepository<RealStateObject> repo, ILocationService _locationService, ICondominiumService condominiumService)
        {
            this._repository = repo;
            this.locationService = _locationService;
            this.condominiumService = condominiumService;
        }

        public async Task<RealStateObject> Create(RealStateObject body)
        {
            body.localizacao = await locationService.Create(body.localizacao) ?? throw CouldNotCreateLocationException.Default();
            return await _repository.Create(body);
        }


        public async Task<bool> Delete(RealStateObject body) => await _repository.Delete(body);

        public async Task<List<RealStateObject>> GetList() => await _repository.Getall();

        public async Task<bool> Update(RealStateObject body) => await _repository.Update(body);

        public async Task<RealStateObject> GetByID(int id) => await _repository.Get(id);
    }
}
