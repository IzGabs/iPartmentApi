using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateRepository : IRealStateRepository<RealStateObject>
    {

        private readonly BuildContext _context;

        public RealStateRepository(BuildContext context)
        {
            _context = context;
        }


        public async Task<RealStateObject> Get(int id) => await _context.RealState
              .Include(l => l.Adress)
              .FirstAsync((x) => x.ID == id);


        public async Task<List<RealStateObject>> Getall() => await _context.RealState
                     .Include(l => l.Adress)
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