using API.src.Core.Filters;
using API.src.Domain.Announcement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Application
{
    public interface IAnnouncementRepository
    {
        Task<AnnouncementAggregate> Create(AnnouncementAggregate @object);
        Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, AnnouncementsFilter filter, int pageSize = 0);
    }
}
