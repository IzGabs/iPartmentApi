using API.Domain.RealState.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.repository
{
    public interface IRealStateRepository
    {

        Task<int?> Create(RealStateObject body);
        Task<bool> Update(RealStateObject body);
        Task<bool> Delete(RealStateObject body);
        Task<List<RealStateObject>> Getall();
        Task<RealStateObject> Get(int? id);

    }
}