using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.ScheduledVisits.Application
{
    public class ScheduledVisitDTO
    {
        [Required]
        public int announcementID { get; set; }

        [Required]
        public int visitorID { get; set; }

        [Required]
        public DateTime date { get; set; }

        public ScheduledVisitDTO(int announcementID, int visitorID, DateTime date)
        {
            this.announcementID = announcementID;
            this.visitorID = visitorID;
            this.date = date;
        }
    }
}
