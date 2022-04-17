using API.Domain.RealState.Models;
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

    public interface IRealStateCondoRepository {
        Task<RealStateCondo> Create(RealStateCondo body);
        Task<RealStateCondo> Get(int id);
    }
}