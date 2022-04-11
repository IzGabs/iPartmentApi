using API.src.Infra.EntityFramework;
using API.Domain.RealState.Models;
using API.src.Domain.Condominium;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Condominium
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly BuildContext _context;

        public CondominiumRepository(BuildContext context) { _context = context; }

        public async Task<List<CondominiumObject>> GetAll() => await _context.Condominium
            .Include(l => l.Location)
            .ToListAsync();

        public async Task<CondominiumObject> Get(int id) => await _context.Condominium
            .Include(l => l.Location)
            .Include(l => l.Values)
            .Include(l => l.realStates)
            .ThenInclude(l => l.Values)
            .FirstOrDefaultAsync(x => x.ID == id);

        public async Task<CondominiumObject> Create(CondominiumObject obj)
        {
            try
            {
                var request = await _context.Condominium.AddAsync(obj);

                if (request.State == EntityState.Added)
                {
                    _context.SaveChanges();
                    return request.Entity;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<bool> Update(CondominiumObject obj)
        {
            try {
                var requestDB =  _context.Condominium.Update(obj);

                if (requestDB.State == EntityState.Modified) {

                    await _context.SaveChangesAsync();
                    return true;
                }
            
            } catch (Exception e) { }

            return false; 
        }
    }
}
