using API.Domain.User;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities;
using API.src.Helpers;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Announcement.Entities
{
    public class AnnouncementAggregate : AnnouncementValueObject
    {
        [Required]
        public UserObject Advertiser { get; set; }

        [Required]
        public RealEstateBase RealEstate { get; set; }

        [Required]
        public AnnouncementSellMonetary RealEstateValues { get; set; }

        public int AnnouncementSellId { get; set; }
        public virtual AnnouncementSellType AnnouncementSell { get; set; }
        public int AnnouncementRentId { get; set; }
        public virtual AnnouncementRentType AnnouncementRent { get; set; }

        protected AnnouncementAggregate() : base() { }

        public AnnouncementAggregate(AnnouncementValueObject vo, UserObject advertiser, RealEstateBase realEstate, AnnouncementSellMonetary realEstateValues)
            : base(vo.ID, vo.createdAt, vo.title, vo.description, vo.immediatelyAvailable)
        {
            this.RealEstateValues = realEstateValues;
            this.Advertiser = advertiser;
            this.RealEstate = realEstate;
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
