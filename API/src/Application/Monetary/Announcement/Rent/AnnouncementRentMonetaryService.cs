using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.Announcement.Rent
{
    public class AnnouncementRentMonetaryService : IMonetaryService<AnnouncementRentMonetary>
    {
        private readonly IMonetaryRepository<AnnouncementRentMonetary> repository;

        public AnnouncementRentMonetaryService(IMonetaryRepository<AnnouncementRentMonetary> repository)
        {
            this.repository = repository;
        }

        public async Task<AnnouncementRentMonetary> Create(AnnouncementRentMonetary obj) => await repository.Create(obj);
    }
}
