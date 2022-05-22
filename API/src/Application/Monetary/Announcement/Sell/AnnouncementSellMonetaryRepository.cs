using API.src.Core.Errors;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Monetary.Entities;
using API.src.Infra.EntityFramework;
using System;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.Announcement.Sell
{
    public class AnnouncementSellMonetaryRepository : IMonetaryRepository<AnnouncementSellMonetary>
    {
        private readonly BuildContext context;

        public AnnouncementSellMonetaryRepository(BuildContext context)
        {
            this.context = context;
        }


        public async Task<AnnouncementSellMonetary> Create(AnnouncementSellMonetary obj)
        {
            try
            {
                var addObj = await context.AnnouncementSellMonetary.AddAsync(obj);

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
