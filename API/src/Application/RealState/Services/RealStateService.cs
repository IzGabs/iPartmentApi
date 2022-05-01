using API.Domain.Location;
using API.src.Controllers.ViewModels;
using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Location;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Application
{
    public class RealStateService : IRealEstateService
    {
        private readonly IRealEstateRepository _repository;
        private readonly ILocationService locationService;
        private readonly IMonetaryService<RealStateMonetary> monetaryService;

        private readonly IRealEstateGetAdvancedRepository _advancedRepo;

        public RealStateService(IRealEstateRepository repository, ILocationService locationService, IMonetaryService<RealStateMonetary> monetaryService, IRealEstateGetAdvancedRepository advancedRepo)
        {
            _repository = repository;
            this.locationService = locationService;
            this.monetaryService = monetaryService;
            _advancedRepo = advancedRepo;
        }

        public async Task<bool> Delete(RealEstateBase body) => await _repository.Delete(body);

        public async Task<List<RealEstateBase>> GetList() => await _repository.GetallComplete();

        public async Task<bool> Update(RealEstateBase body) => await _repository.Update(body);

        public async Task<RealEstateBase> GetByID(int id) => await _repository.Get(id);

        public async Task<RealEstateBase> Create(RealEstateBase body)
        {
            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();
            body.Values = await monetaryService.Create(body.Values) ?? throw CouldNotCreateRealStateValues.Default();
            return await _repository.Create(body);
        }

        public async Task<List<RealEstateBase>> GetListPagineted(string city, int page, int pageSize = 0) => await _advancedRepo.GetFromCityLimited(city, page, pageSize);
    }
}
