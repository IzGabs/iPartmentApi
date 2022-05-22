using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Announcement.Entities
{
    public enum AnnouncementTypeEnum
    {
        Sell = 0,
        Rent = 1,
    }

    public class AnnouncementValueObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        public DateTime createdAt { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public bool immediatelyAvailable { get; set; }

        protected AnnouncementValueObject() { }

        public AnnouncementValueObject(int? iD, DateTime createdAt, string title, string description, bool immediatelyAvailable)
        {
            ID = iD;
            this.createdAt = createdAt;
            this.title = title;
            this.description = description;
            this.immediatelyAvailable = immediatelyAvailable;
        }
    }
}
