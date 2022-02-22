using API.Domain.Models;
using API.Domain.RealState.Models;
using API.src.Domain.RealState.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateRepository : IRealStateRepository
    {

        private readonly BuildContext _context;

       public RealStateRepository(BuildContext context)
        {
            _context = context;
        }


        public async Task<RealStateObject> Get(int? id)
        {
            if (id == null) throw null;
            return await _context.RealState.FindAsync(id);
        }


        public async Task<List<RealStateObject>> Getall()
        {
            return await _context.RealState.ToListAsync();
        }


        public async Task<int?> Create(RealStateObject body)
        {
            await _context.RealState.AddAsync(body);
            return body.ID;
        }

        public async Task<bool> Delete(RealStateObject body)
        {
            try
            {
                var returnRemove = _context.RealState.Remove(body);

                return returnRemove.State == EntityState.Deleted ;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<bool> Update(RealStateObject body)
        {
            try
            {
               var updateReturn =  _context.RealState.Update(body);

                return updateReturn.State == EntityState.Modified;
            }
            catch
            {
                return false;
            }
        }
    }
}