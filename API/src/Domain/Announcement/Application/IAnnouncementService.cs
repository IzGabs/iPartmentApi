using API.src.Controllers.Announcement.ViewModel;
using API.src.Core.Filters;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary;
using API.src.Domain.Monetary.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Application
{
    public interface IAnnouncementService
    {
        Task<AnnouncementAggregate> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement, IMonetaryEntity monetary, AnnouncementTypeEnum type);
        Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, AnnouncementsFilter filter, int pageSize = 0);
        Task<AnnouncementAggregate> GetByID(int id);

        Task<List<AnnouncementAggregate>> GetByCity(string city);


        Task Delete(int iD);
      //  Task<List<AnnouncementAggregate>> Update(AnnouncementResponseViewModel body);
    }
}
