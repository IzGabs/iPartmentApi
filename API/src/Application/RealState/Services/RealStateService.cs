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
        private readonly IRealStateGetAdvancedRepository _advancedRepo;

        public RealStateService(IRealStateRepository repository, ILocationService locationService, IRealStateGetAdvancedRepository advancedRepo)
        {
            _repository = repository;
            this.locationService = locationService;
            _advancedRepo = advancedRepo;
        }

        public async Task<bool> Delete(RealStateBase body) => await _repository.Delete(body);

        public async Task<List<RealStateBase>> GetList() => await _repository.GetallComplete();

        public async Task<bool> Update(RealStateBase body) => await _repository.Update(body);

        public async Task<RealStateBase> GetByID(int id) => await _repository.Get(id);

        public async Task<RealStateBase> Create(RealStateBase body)
        {
            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();
           // body.Values = await 
            return await _repository.Create(body);
        }

        public async Task<List<RealStateBase>> GetListPagineted(string city, int page, int pageSize = 0) => await _advancedRepo.GetFromCityLimited(city, page, pageSize);
    }
}
