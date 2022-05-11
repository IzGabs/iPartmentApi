using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Infra.EntityFramework;
using System;
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
            return (await context.Announcements.AddAsync(@object)).Entity;
        }
    }
}
