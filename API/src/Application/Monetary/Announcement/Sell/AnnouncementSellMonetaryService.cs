using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.Announcement.Sell
{
    public class AnnouncementSellMonetaryService : IMonetaryService<AnnouncementSellMonetary>
    {
        private readonly IMonetaryRepository<AnnouncementSellMonetary> repository;

        public AnnouncementSellMonetaryService(IMonetaryRepository<AnnouncementSellMonetary> repository)
        {
            this.repository = repository;
        }

        public async Task<AnnouncementSellMonetary> Create(AnnouncementSellMonetary obj) => await repository.Create(obj);
    }
}
