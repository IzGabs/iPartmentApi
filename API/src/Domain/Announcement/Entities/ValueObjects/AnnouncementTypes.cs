using API.src.Domain.Monetary;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.Announcement.Entities
{
    public abstract class AnnouncementType
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public IMonetaryEntity typeMonetary;

        [Required]
        public AnnouncementAggregate Aggregate { get; set; }
    }
}
