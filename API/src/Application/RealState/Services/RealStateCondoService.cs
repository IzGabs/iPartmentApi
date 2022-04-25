using API.src.Controllers.ViewModels;
using API.src.Core.Errors;
using API.src.Domain.Condominium;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Location;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateCondoService : IRealStateCondoService
    {
        private readonly IRealStateCondoRepository _repository;
        private readonly ICondominiumService condominiumService;
        private readonly IMonetaryService<RealStateMonetary> monetaryService;

        public RealStateCondoService(IRealStateCondoRepository repository, ICondominiumService condominiumService, IMonetaryService<RealStateMonetary> monetaryService)
        {
            _repository = repository;
            this.condominiumService = condominiumService;
            this.monetaryService = monetaryService;
        }

        public async Task<RealStateCondo> GetByID(int id) => await _repository.Get(id);
 
        public async Task<RealStateCondo> Create(Domain.RealState.Entities.RealStateBase body, int condoId)
        {
            var condominium = await condominiumService.Get(condoId) ?? throw CondoNotFoundException.Default();
            body.Values = await monetaryService.Create(body.Values) ?? throw CouldNotCreateRealStateValues.Default();

            var realStateCondo = new RealStateCondo(body, condo:condominium);

            return await _repository.Create(realStateCondo);
        }

    }
}
