using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealStateRepository<T> where T : RealStateObject
    {

        Task<T> Create(T body);
        Task<bool> Update(T body);
        Task<bool> Delete(T body);
        Task<List<T>> Getall();
        Task<T> Get(int id);

    }
}