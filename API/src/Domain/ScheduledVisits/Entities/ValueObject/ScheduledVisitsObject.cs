using API.Domain.User;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities;
using API.src.Domain.ScheduledVisits.Application;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.ScheduledVisits.Entities.ValueObject
{
    [Table("ScheduledVisits")]
    public class ScheduledVisitsObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int? ID { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public AnnouncementAggregate announcement { get; set; }

        [Required]
        public UserObject visitor { get; set; }

        public ScheduledVisitsObject() { }

        public ScheduledVisitsObject(DateTime date, AnnouncementAggregate announcement, UserObject visitor)
        {

            this.date = date;
            this.announcement = announcement;
            this.visitor = visitor;
        }
    }
}
