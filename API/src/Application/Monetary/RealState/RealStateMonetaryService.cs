using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.RealState
{
    public class RealStateMonetaryService : IMonetaryService<RealStateMonetary>
    {
        private readonly IMonetaryRepository<RealStateMonetary> repository;

        public RealStateMonetaryService(IMonetaryRepository<RealStateMonetary> repository)
        {
            this.repository = repository;
        }

        public async Task<RealStateMonetary> Create(RealStateMonetary obj) => await repository.Create(obj);
    }
}
