using API.src.Application.Location;
using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Location;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateCondoService : IRealEstateCondoService
    {
        private readonly IRealEstateRepository _repository;
        private readonly ICondominiumService condominiumService;
        private readonly ILocationService locationService;

        public RealStateCondoService(IRealEstateRepository repository, ICondominiumService condominiumService, ILocationService locationService)
        {
            _repository = repository;
            this.condominiumService = condominiumService;
            this.locationService = locationService;
        }

        public async Task<RealEstateBase> GetByID(int id) => await _repository.Get(id);

        public async Task<RealEstateBase> Create(RealEstateBase body, int condoId)
        {
            var condominium = await condominiumService.Get(condoId) ?? throw CondoNotFoundException.Default();
            body.Condominium = condominium;
            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();

            return await _repository.Create(body);
        }

    }
}
