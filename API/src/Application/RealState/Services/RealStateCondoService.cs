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

        public async Task<List<RealStateObject>> GetList() => await _repository.GetallComplete();

        public async  Task<List<RealStateObject>> GetListSimple() => await _repository.GetAllSimple();

        public async Task<bool> Delete(RealStateObject body) => await _repository.Delete(body);

        public async Task<RealStateObject> GetByID(int id) => await _repository.Get(id);

        public async Task<bool> Update(RealStateObject body) => await _repository.Update(body);

        public async Task<RealStateObject> Create(RealStateObject body, int condoId)
        {
            var condominium = await condominiumService.Get(condoId) ?? throw CondoNotFoundException.Default();

            body.Condominium = condominium;
            body.Adress = condominium.Location;

            return await _repository.Create(body);
        }

    }
}
