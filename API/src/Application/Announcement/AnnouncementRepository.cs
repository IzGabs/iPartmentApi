using API.src.Core.Filters;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
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
    }
}
