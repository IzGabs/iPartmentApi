using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateCondoService : IRealEstateCondoService
    {
        private readonly IRealEstateCondoRepository _repository;
        private readonly ICondominiumService condominiumService;

        public RealStateCondoService(IRealEstateCondoRepository repository, ICondominiumService condominiumService)
        {
            _repository = repository;
            this.condominiumService = condominiumService;
        }

        public async Task<RealEstateCondo> GetByID(int id) => await _repository.Get(id);

        public async Task<RealEstateCondo> Create(RealEstateBase body, int condoId)
        {
            var condominium = await condominiumService.Get(condoId) ?? throw CondoNotFoundException.Default();
            var realStateCondo = new RealEstateCondo(body, condo: condominium);
            return await _repository.Create(realStateCondo);
        }

    }
}
