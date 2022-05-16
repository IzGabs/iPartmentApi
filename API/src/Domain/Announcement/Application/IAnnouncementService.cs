using API.src.Core.Filters;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Application
{
    public interface IAnnouncementService
    {
        Task<AnnouncementAggregate> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement, AnnouncementSellMonetary monetary);
        Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, AnnouncementsFilter filter, int pageSize = 0);
    }
}
