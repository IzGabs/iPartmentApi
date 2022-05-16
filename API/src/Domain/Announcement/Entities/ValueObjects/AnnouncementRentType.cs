using API.src.Domain.Monetary.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.Announcement.Entities
{
    public class AnnouncementRentType : AnnouncementType
    {
        protected AnnouncementRentType() { }

        public AnnouncementRentType(float montlyValue, float iPTU, AnnouncementAggregate announcement)
        {
            this.typeMonetary = new AnnouncementRentMonetary(montlyValue, iPTU);
            this.Aggregate = announcement;
        }
    }
}
