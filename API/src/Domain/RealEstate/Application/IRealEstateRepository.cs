using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateRepository
    {

        Task<bool> Update(RealEstateBase body);
        Task<bool> Delete(RealEstateBase body);
        Task<RealEstateBase> Create(RealEstateBase body);
        Task<List<RealEstateBase>> GetallComplete();
        Task<RealEstateBase> Get(int id);
    }

    public interface IRealEstateCondoRepository {
        Task<RealEstateCondo> Create(RealEstateCondo body);
        Task<RealEstateCondo> Get(int id);
    }
}