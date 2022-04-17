
using API.src.Controllers.ViewModels;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateService
    {
        Task<RealStateObject> Create(RealStateObject body);
        Task<bool> Update(RealStateObject body);
        Task<bool> Delete(RealStateObject body);
        Task<List<RealStateObject>> GetList();
        Task<RealStateObject> GetByID(int id);
    }

    public interface IRealStateCondoService
    {
        Task<RealStateCondo> Create(RealStateObject body, int condoId);
        Task<RealStateCondo> GetByID(int id);
    }
}
