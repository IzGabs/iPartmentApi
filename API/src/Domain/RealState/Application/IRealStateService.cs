
using API.src.Domain.RealState.Entities;
using API.src.Controllers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateService
    {
        Task<bool> Update(RealStateBase body);
        Task<bool> Delete(RealStateBase body);
        Task<RealStateBase> Create(RealStateBase body);

        Task<RealStateBase> GetByID(int id);
        Task<List<RealStateBase>> GetList();
        Task<List<RealStateBase>> GetListPagineted(string city, int page, int pageSize = 0);
    }

    public interface IRealStateCondoService
    {
        Task<RealStateCondo> Create(RealStateBase body, int condoId);
        Task<RealStateCondo> GetByID(int id);
    }
}
