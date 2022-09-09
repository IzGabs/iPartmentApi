using API.src.Core.Filters;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Announcement
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        protected BuildContext context;

        public AnnouncementRepository(BuildContext context)
        {
            this.context = context;
        }

        public async Task<AnnouncementAggregate> Create(AnnouncementAggregate @object)
        {
            var add = await context.Announcements.AddAsync(@object);
            await context.SaveChangesAsync();

            return add.Entity;
        }

        public async Task Delete(AnnouncementAggregate an)
        {
            context.Announcements.Remove(an);
            await context.SaveChangesAsync();
        }

        public async Task<AnnouncementAggregate> GetByID(int id) => await context.Announcements
            .Include(x => x.Advertiser)
            .Include(x => x.RealEstate)
            .ThenInclude(l => l.Adress)
            .Include(x => x.RealEstate.Condominium)
            .ThenInclude(l => l.Values)
            .FirstAsync(x => x.ID == id);

        public Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, AnnouncementsFilter filter, int pageSize = 0)
        {
            var request = context.Announcements
                .Include(l => l.RealEstate)
                .Include(l => l.RealEstate.Adress)
                .Include(l => l.SellValues)
                .Include(l => l.RentValues)
                .Include(l => l.RealEstate.Type)
                .Where(
                    query =>
                    query.RealEstate.Adress.City == city &&
                    query.RealEstate.Type.Id == (int)filter.Type &&
                    query.RealEstate.Rooms == filter.dorms &&
                    query.RealEstate.Bathrooms == filter.bathrooms &&
                    query.RealEstate.Garage == filter.garage &&
                    query.RealEstate.AllowPets == filter.pets &&
                    query.RealEstate.Furnished == filter.furnished &&

                 (query.RentValues.valorTotal() >= filter.ValueFilter.minValue &&
                 query.RentValues.valorTotal() <= filter.ValueFilter.maxValue)
                )
                .Take(20);

            return null;
        }

        public async Task<List<AnnouncementAggregate>> SearchByCity(string city)
        {
            try
            {
                return await context.Announcements
                    .Include(l => l.Advertiser)

                    .Include(x => x.RealEstate)
                    .ThenInclude(l => l.Adress)
                    .Include(l=> l.RealEstate.images)
                    .Include(l => l.RealEstate.Type)
                    .Include(x => x.RealEstate.Condominium)
                    .ThenInclude(l => l.Values)

                    .Include(l => l.SellValues)
                    .Include(l => l.RentValues)

                    .Where(x => x.RealEstate.Adress.City.ToUpper() == city.ToUpper())
                    .Take(20)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
