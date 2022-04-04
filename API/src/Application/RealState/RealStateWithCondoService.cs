using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Location;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateWithCondoService : IRealStateService<RealStateWithCondo>
    {
        private readonly IRealStateRepository<RealStateWithCondo> _repository;
        private readonly ILocationService locationService;
        private readonly ICondominiumService condominiumService;

        public RealStateWithCondoService(IRealStateRepository<RealStateWithCondo> repo, ILocationService _locationService, ICondominiumService condominiumService)
        {
            this._repository = repo;
            this.locationService = _locationService;
            this.condominiumService = condominiumService;
        }


        public async Task<RealStateWithCondo> Create(RealStateWithCondo body)
        {

            body.Condominio = await condominiumService.Get((int)body.Condominio.ID) ?? throw CondoNotFoundException.Default();

            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();

            return await _repository.Create(body);
        }

        public async Task<bool> Delete(RealStateWithCondo body) => await _repository.Delete(body);

        public async Task<RealStateWithCondo> GetByID(int id) => await _repository.Get(id);

        public async Task<List<RealStateWithCondo>> GetList() => await _repository.Getall();

        public async Task<bool> Update(RealStateWithCondo body) => await _repository.Update(body);
    }
}
