using API.Domain.RealState.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPartmentApi.src.Domain.RealState.repository
{
    public interface IRealStateRepository 
    {

        Task<bool> IsRealStateValid();
        Task<int> Create();
        Task<bool> Update();
        Task<bool> Delete();
        Task<List<RealStateObject>> Getall();
        Task<RealStateObject> Get(int id);

    }
}