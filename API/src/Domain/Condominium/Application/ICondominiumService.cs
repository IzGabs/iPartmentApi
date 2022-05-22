using API.Domain.RealState.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium
{
    public interface ICondominiumService
    {
        Task<CondominiumObject> Create(CondominiumObject obj);
        Task<CondominiumObject> Get(int id);
        Task<CondominiumObject> GetRealStates(int id);
        Task<List<CondominiumObject>> GetAll();
    }
}
