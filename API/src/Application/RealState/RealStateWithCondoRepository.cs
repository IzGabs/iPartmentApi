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
    public class RealStateWithCondoRepository : IRealStateRepository<RealStateWithCondo>
    {
        private readonly BuildContext _context;

        public RealStateWithCondoRepository(BuildContext context)
        {
            _context = context;
        }


        public async Task<RealStateWithCondo> Get(int id) => await _context.RealStateWithCondo
            .Include(l => l.Adress)
            .Include(l => l.Condominio)
            .FirstAsync((x) => x.ID == id);


        public async Task<List<RealStateWithCondo>> Getall() => await _context.RealStateWithCondo
                     .Include(l => l.Adress)
                     .Include(l => l.Condominio)
                     .ToListAsync();

        public async Task<RealStateWithCondo> Create(RealStateWithCondo body)
        {
            try
            {
                var request = await _context.RealStateWithCondo.AddAsync(body);
                await _context.SaveChangesAsync();

                return request.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }


        public async Task<bool> Delete(RealStateWithCondo body)
        {
            try
            {
                var returnRemove = _context.RealStateWithCondo.Remove(body);
                await _context.SaveChangesAsync();

                return returnRemove.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public async Task<bool> Update(RealStateWithCondo body)
        {
            try
            {
                var updateReturn = _context.RealStateWithCondo.Update(body);
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
