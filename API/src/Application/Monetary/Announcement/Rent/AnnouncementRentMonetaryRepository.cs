using API.src.Core.Errors;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Monetary.Entities;
using API.src.Infra.EntityFramework;
using System;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.Announcement.Rent
{
    public class AnnouncementRentMonetaryRepository : IMonetaryRepository<AnnouncementRentMonetary>
    {
        private readonly BuildContext context;

        public AnnouncementRentMonetaryRepository(BuildContext context)
        {
            this.context = context;
        }


        public async Task<AnnouncementRentMonetary> Create(AnnouncementRentMonetary obj)
        {
            try
            {
                var addObj = await context.AnnouncementRentMonetary.AddAsync(obj);

                if (addObj.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    await context.SaveChangesAsync();
                    return addObj.Entity;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw CouldNotCreateRealStateValues.Default();
            }

            return null;
        }
    }
}
