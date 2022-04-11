using API.Domain.Location;
using API.src.Controllers.ViewModels;
using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Location;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
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
            this._repository = repo;
            this.locationService = _locationService;
        }

        public async Task<bool> Delete(RealStateObject body) => await _repository.Delete(body);

        public async Task<List<RealStateObject>> GetList() => await _repository.GetallComplete();

        public async Task<bool> Update(RealStateObject body) => await _repository.Update(body);

        public async Task<RealStateObject> GetByID(int id) => await _repository.Get(id);

        public async Task<RealStateObject> Create(RealStateObject body)
        {
            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();
            return await _repository.Create(body);
        }
    }
}
