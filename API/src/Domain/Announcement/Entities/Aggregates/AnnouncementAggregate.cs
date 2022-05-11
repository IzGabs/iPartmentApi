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
    public class AnnouncementAggregate : AnnouncementValueObject
    {
        [Required]
        public UserObject Advertiser { get; set; }
        [Required]
        public RealEstateBase RealEstate { get; set; }

        protected AnnouncementAggregate() : base() { }

        public AnnouncementAggregate(
            AnnouncementValueObject vo,
            UserObject advertiser,
            RealEstateBase realEstate) : base(vo.ID, vo.createdAt, vo.title, vo.description, vo.immediatelyAvailable)
        {

            Advertiser = advertiser;
            RealEstate = realEstate;
        }

        public AnnouncementAggregate(
            int? iD, DateTime createdAt,
            string title,
            string description,
            bool immediatelyAvailable,
            UserObject advertiser,
            RealEstateBase realEstate
            )
        {
            this.ID = ID;
            this.createdAt = createdAt;
            this.title = description;
            this.immediatelyAvailable = immediatelyAvailable;

            Advertiser = advertiser;
            RealEstate = realEstate;
        }
    }
}
