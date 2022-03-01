using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Condominium.Monetary
{
    public class CondoMonetaryService : IMonetaryService<CondominiumMonetary>
    {
        private readonly IMonetaryRepository<CondominiumMonetary> repository;

        public CondoMonetaryService(IMonetaryRepository<CondominiumMonetary> repository) { this.repository = repository; }

        public async Task<CondominiumMonetary> Create(CondominiumMonetary obj) => await repository.Create(obj);
    }
}
