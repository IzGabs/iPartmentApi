using API.src.Domain.Monetary.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.Announcement.Entities
{

    public class AnnouncementSellType : AnnouncementType
    {
        protected AnnouncementSellType() { }

        public AnnouncementSellType(float value, AnnouncementAggregate announcement)
        {
            this.typeMonetary = new AnnouncementSellMonetary(value) ;
            this.Aggregate = announcement;
        }
    }
}
