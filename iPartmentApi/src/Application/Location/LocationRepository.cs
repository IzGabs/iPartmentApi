using API.Domain.Location;
using API.Domain.Models;
using API.src.Domain.Location;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Location
{
    public class LocationRepository : ILocationRepository
    {
        private readonly BuildContext _context;

        public LocationRepository(BuildContext context)
        {
            _context = context;
        }

        public async Task<Address> Create(Address adress)
        {
            var request = await _context.Addresses.AddAsync(adress);
            await _context.SaveChangesAsync();
            return request.Entity;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Edit(int id, Address adress)
        {
            throw new NotImplementedException();
        }
    }
}
