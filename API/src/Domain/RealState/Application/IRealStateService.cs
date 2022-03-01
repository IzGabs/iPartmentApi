
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateService<T> where T : RealStateObject
    {
        Task<T> Create(T body);
        Task<bool> Update(T body);
        Task<bool> Delete(T body);
        Task<List<T>> GetList();
        Task<T> GetByID(int id);
    }
}
