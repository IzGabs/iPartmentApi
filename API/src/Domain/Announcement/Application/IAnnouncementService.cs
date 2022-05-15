using API.src.Domain.Announcement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Application
{
   public interface IAnnouncementService
    {
        Task<AnnouncementAggregate> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement);
        Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, int pageSize = 0);
    }
}
