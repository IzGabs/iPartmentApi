using API.src.Domain.RealEstate;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
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

        public async Task<RealEstateBase> Get(int id) => await
            _context.Set<RealEstateBase>()
              .Include(l => l.Adress)
              .Include(l => l.Type)
            .Include(l => l.Condominium)
            .ThenInclude(l => l.Values)
            .FirstOrDefaultAsync((x) => x.ID == id);


        public async Task<List<RealEstateBase>> GetAll() => await
            _context.Set<RealEstateBase>()
              .Include(l => l.Adress)
              .Include(l => l.Type)
              .Include(l => l.Condominium)
            .ThenInclude(l => l.Values)
              .ToListAsync();



        public async Task<RealEstateBase> Create(RealEstateBase body)
        {
            try
            {
                body.Type = _context.RealEstateTypes.FirstOrDefault(x => x.Id == body.Type.Id);

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


    }
}