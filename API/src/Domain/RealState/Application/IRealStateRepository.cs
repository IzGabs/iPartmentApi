using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateRepository
    {

        Task<bool> Update(RealStateBase body);
        Task<bool> Delete(RealStateBase body);
        Task<RealStateBase> Create(RealStateBase body);
        Task<List<RealStateBase>> GetallComplete();
        Task<RealStateBase> Get(int id);
    }

    public interface IRealStateCondoRepository {
        Task<RealStateCondo> Create(RealStateCondo body);
        Task<RealStateCondo> Get(int id);
    }
}