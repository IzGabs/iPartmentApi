using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Entities
{
    public enum AnnouncementTypeEnum
    {
        Sell = 0,
        Rent = 1
    }

    public abstract class AnnouncementType
    {
        [Required]
        public int? ID { get; set; }

        [Required]
        public AnnouncementTypeEnum type;

        [Required]
        public Announcement announcement { get; set; }
    }
}
