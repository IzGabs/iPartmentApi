using API.src.Core.Errors;
using API.src.Domain.Location;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Threading.Tasks;

namespace API.Application
{
    public class RealStateService : IRealEstateService
    {
        private readonly IRealEstateRepository _repository;
        private readonly ILocationService locationService;

        public RealStateService(IRealEstateRepository repository, ILocationService locationService)
        {
            _repository = repository;
            this.locationService = locationService;
        }

        public async Task<RealEstateBase> GetByID(int id) => await _repository.Get(id);

        public async Task<RealEstateBase> Create(RealEstateBase body)
        {
            body.Adress = await locationService.Create(body.Adress) ?? throw CouldNotCreateLocationException.Default();

            return await _repository.Create(body);
        }
    }
}
