using API.src.Domain.Announcement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Application
{
   public interface IAnnouncementRepository
    {
        Task<AnnouncementAggregate> Create(AnnouncementAggregate @object);
    }
}
