using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.RealState.Repository
{
    public class RealStateGetAdvanced : IRealStateGetAdvancedRepository
    {

        private readonly BuildContext _context;

        public RealStateGetAdvanced(BuildContext context)
        {
            _context = context;
        }

        public async Task<List<RealStateBase>> GetFromCityLimited(string city, int page, int pageSize = 0) => await _context.RealState
            .Include(l => l.Adress)
            .Include(l => l.CurrentResident)
            .Include(l => l.Values)
           // .Include("Condominium")
            .Where(x => x.CurrentResident == null && x.Adress.City == city)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
