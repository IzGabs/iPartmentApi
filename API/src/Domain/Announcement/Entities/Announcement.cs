using API.Domain.User;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Announcement.Entities
{
    public class Announcement
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
        [Required]
        public UserObject Advertiser { get; set; }
        [Required]
        public RealEstateBase RealEstate { get; set; }

        protected Announcement() { }
        public Announcement( string title, string description, bool immediatelyAvailable, UserObject advertiser, RealEstateBase RealEstate)
        {   
            this.createdAt = DateTime.Now;
            this.title = title;
            this.description = description;
            this.immediatelyAvailable = immediatelyAvailable;
            this.Advertiser = advertiser;
            this.RealEstate = RealEstate;
        }
    }
}
