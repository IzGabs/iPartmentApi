using API.Domain.RealState.Models;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateCondoRepository : IRealStateCondoRepository
    {
        private readonly BuildContext _context;

        public RealStateCondoRepository(BuildContext context)
        {
            _context = context;
        }

        public async Task<RealStateCondo> Get(int id) => await _context.RealStateCondo
            .Include(l => l.Adress)
            .Include(l => l.Values)
            .Include(l => l.CurrentResident)
            .Include(l => l.Condominium)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id);


        public async Task<RealStateCondo> Create(RealStateCondo body)
        {
            try
            {
                var request = await _context.RealStateCondo.AddAsync(body);
                await _context.SaveChangesAsync();

                return request.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }       
    }
}
