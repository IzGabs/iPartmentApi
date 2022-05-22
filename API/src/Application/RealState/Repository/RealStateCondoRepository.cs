using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.src.Application.RealState
{
    public class RealStateCondoRepository : IRealEstateCondoRepository
    {
        private readonly BuildContext _context;

        public RealStateCondoRepository(BuildContext context)
        {
            _context = context;
        }

        public async Task<RealEstateCondo> Get(int id) => await _context.RealEstateCondo
            .Include(l => l.Adress)
            .Include(l => l.CurrentResident)
            .Include(l => l.Condominium)
            .ThenInclude(l => l.Values)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id);


        public async Task<RealEstateCondo> Create(RealEstateCondo body)
        {
            try
            {
                var request = await _context.RealEstateCondo.AddAsync(body);
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
