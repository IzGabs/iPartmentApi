using API.Domain.RealState.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium
{
    public interface ICondominiumRepository
    {
        Task<CondominiumObject> Create(CondominiumObject obj);
        Task<CondominiumObject> Get(int id);
        Task<CondominiumObject> GetRealStates(int id);
        Task<List<CondominiumObject>> GetAll();
        Task<bool> Update(CondominiumObject obj);
    }
}
