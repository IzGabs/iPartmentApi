using API.Domain.RealState.Models;
using API.src.Domain.RealState.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.RealState
{
    public interface IRealStateService
    {

        Task<RealStateObject> Create(RealStateObject body);
        Task<bool> Update(RealStateObject body);
        Task<bool> Delete(RealStateObject body);
        Task<List<RealStateObject>> GetList();
        Task<RealStateObject> GetByID(int id);
    }
}
