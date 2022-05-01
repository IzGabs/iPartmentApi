using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateGetAdvancedRepository
    {
        Task<List<RealEstateBase>> GetFromCityLimited(string city, int page, int pageSize = 0);
    }
}
