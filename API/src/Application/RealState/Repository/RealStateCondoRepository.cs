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

        public async Task<RealStateObject> Get(int id) => await _context.RealState
            .Include(l => l.Adress)
            .Include(l => l.Values)
            .Include(l => l.CurrentResident)
            .Include(l => l.Condominium)
            .Include(l => l.Condominium.Values)
            .Include(l => l.Condominium.Location)
            .Include(l => l.Condominium.Values)
            .AsNoTracking()
            .FirstAsync((x) => x.ID == id);


        public async Task<List<RealStateObject>> GetallComplete() => await _context.RealState
            .Include(l => l.Adress)
            .Include(l => l.Values)
            .Include(l => l.CurrentResident)
            .Include(l => l.Condominium)
            .Include(l => l.Condominium.Location)
            .Include(l => l.Condominium.Values)
            .AsNoTracking()
            .Where(x => x.Condominium != null)
            .ToListAsync();

        public async Task<List<RealStateObject>> GetAllSimple() => await _context.RealState
            .Include(l => l.Adress)
            .Include(l => l.Values)
            .Include(l => l.Condominium)
            .Include(l => l.Condominium.Values)
            .AsNoTracking()
            .Where(x => x.Condominium != null)
            .ToListAsync();


        public async Task<RealStateObject> Create(RealStateObject body)
        {
            try
            {
                var request = await _context.RealState.AddAsync(body);
                await _context.SaveChangesAsync();

                return request.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }


        public async Task<bool> Delete(RealStateObject body)
        {
            try
            {
                var returnRemove = _context.RealState.Remove(body);
                await _context.SaveChangesAsync();

                return returnRemove.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public async Task<bool> Update(RealStateObject body)
        {
            try
            {
                var updateReturn = _context.RealState.Update(body);
                await _context.SaveChangesAsync();

                return updateReturn.State == EntityState.Modified;
            }
            catch
            {
                return false;
            }
        }

       
    }
}
