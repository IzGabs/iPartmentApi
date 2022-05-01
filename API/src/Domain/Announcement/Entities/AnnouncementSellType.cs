using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Entities
{
   
    public class AnnouncementSellType : AnnouncementType
    {
        protected AnnouncementSellType() { }

        public AnnouncementSellType(float value, float iPTU, Announcement announcement) 
        {
            Value = value;
            IPTU = iPTU;
            this.type = AnnouncementTypeEnum.Sell;
            this.announcement = announcement;
        }

        [Required]
        public float Value { get; set; }
        [Required]
        public float IPTU { get; set; }
    }
}
