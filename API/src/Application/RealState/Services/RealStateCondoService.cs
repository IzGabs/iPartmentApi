using API.src.Controllers.ViewModels;
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
    public class RealStateCondoService : IRealStateCondoService
    {
        private readonly IRealStateCondoRepository _repository;
        private readonly ICondominiumService condominiumService;

        public RealStateCondoService(IRealStateCondoRepository repo, ICondominiumService condominiumService)
        {
            this._repository = repo;
            this.condominiumService = condominiumService;
        }

        public async Task<RealStateCondo> GetByID(int id) => await _repository.Get(id);
 
        public async Task<RealStateCondo> Create(Domain.RealState.Entities.RealStateBase body, int condoId)
        {
            var condominium = await condominiumService.Get(condoId) ?? throw CondoNotFoundException.Default();

            var realStateCondo = new RealStateCondo(body, condo:condominium);

            return await _repository.Create(realStateCondo);
        }

    }
}
