using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduledVisitsRepository : IScheduledVisitsRepository
    {
        private readonly BuildContext _context;

        public ScheduledVisitsRepository(BuildContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ScheduledVisitsObject obj)
        {
            try
            {
                var req = await _context.ScheduledVisits.AddAsync(obj);
                var save = await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error trying to schedule a Visit " + e.Message);
                return false;
            }
        }


        public IEnumerable<ScheduledVisitsObject> GetAllVisitsOfUsers(int id)
        {
            try
            {
                var qeury = _context.ScheduledVisits
                   .Include(l => l.visitor)
                   .Include(l => l.announcement)
                   .ThenInclude(l => l.RealEstate)
                   .ThenInclude(l => l.Adress)
                   .Where(x => x.visitor.ID == id);

                return qeury;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IEnumerable<ScheduledVisitsObject> GetAllVisitsOfAgent(int id)
        {
            try
            {
                var qeury = _context.ScheduledVisits
                   .Include(l => l.visitor)
                   .Include(l => l.announcement)
                   .Where(x => x.announcement.Advertiser.ID == id);

                return qeury;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IEnumerable<ScheduledVisitsObject> GetAllScheduledVisitsFromAnnounce(int id)
        {
            try
            {
                var qeury = _context.ScheduledVisits
                   .Include(_l => _l.visitor)
                   .Where(x => x.announcement.Advertiser.ID == id);

                return qeury;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }


        public ScheduledVisitsObject GetById(int id) => _context.ScheduledVisits
            .Include(l => l.visitor)
            .Include(l => l.announcement)
            .ThenInclude(l => l.RealEstate)
            .FirstOrDefault(x => x.ID == id);

    }
}
