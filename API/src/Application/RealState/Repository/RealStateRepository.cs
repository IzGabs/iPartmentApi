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
    public class RealStateRepository : IRealEstateRepository
    {

        private readonly BuildContext _context;

        public RealStateRepository(BuildContext context)
        {
            _context = context;
        }


        public async Task<RealEstateBase> Get(int id) => await _context.RealEstate
              .Include(l => l.Adress)
              .Include(l => l.Values)
              .Include(l => l.Adress)
              .FirstOrDefaultAsync((x) => x.ID == id);


        public async Task<List<RealEstateBase>> GetallComplete() => await _context.RealEstate
                     .Include(l => l.Adress)
                     .ToListAsync();


        public async Task<RealEstateBase> Create(RealEstateBase body)
        {
            try
            {
                var request = await _context.RealEstate.AddAsync(body);
                await _context.SaveChangesAsync();

                return request.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }

        public async Task<bool> Delete(RealEstateBase body)
        {
            try
            {
                var returnRemove = _context.RealEstate.Remove(body);
                await _context.SaveChangesAsync();

                return returnRemove.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Update(RealEstateBase body)
        {
            try
            {
                var updateReturn = _context.RealEstate.Update(body);
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