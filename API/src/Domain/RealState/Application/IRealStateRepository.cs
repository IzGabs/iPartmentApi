using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateRepository
    {

        Task<RealStateObject> Create(RealStateObject body);
        Task<bool> Update(RealStateObject body);
        Task<bool> Delete(RealStateObject body);
        Task<List<RealStateObject>> GetallComplete();
        
        Task<RealStateObject> Get(int id);

    }

    public interface IRealStateCondoRepository : IRealStateRepository{
        Task<List<RealStateObject>> GetAllSimple();
    }
}