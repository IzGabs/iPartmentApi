using API.Domain.RealState.Models;
using iPartmentApi.src.Domain.RealState.repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPartmentApi.src.Application.RealState
{
    public class RealStateRepository : IRealStateRepository
    {
        public Task<int> Create()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new System.NotImplementedException();
        }

        public Task<RealStateObject> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<RealStateObject>> Getall()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsRealStateValid()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}