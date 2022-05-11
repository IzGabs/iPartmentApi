using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Entities
{
    public class AnnouncementRentType : AnnouncementType
    {

        protected AnnouncementRentType() { }

        public AnnouncementRentType(float montlyValue, float iPTU, AnnouncementAggregate announcement)
        {
            this.montlyValue = montlyValue;
            IPTU = iPTU;
            this.type = AnnouncementTypeEnum.Rent;
            this.announcement = announcement;
        }

        [Required]
        public float montlyValue { get; set; }
        [Required]
        public float IPTU { get; set; }
    }
}
