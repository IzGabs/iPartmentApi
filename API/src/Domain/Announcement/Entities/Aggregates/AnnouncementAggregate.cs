using API.Domain.User;
using API.src.Domain.Monetary;
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
        public AnnouncementTypeEnum type { get; set; }

       
        public virtual AnnouncementSellMonetary? SellValues { get; set; }
        public virtual AnnouncementRentMonetary? RentValues { get; set; }

        public int? AnnouncementSellId { get; set; }
        public int? AnnouncementRentId { get; set; }

        protected AnnouncementAggregate() : base() { }

        public AnnouncementAggregate(AnnouncementValueObject vo, UserObject advertiser, RealEstateBase realEstate, AnnouncementTypeEnum type,  IMonetaryEntity values)
            : base(vo.ID, vo.createdAt, vo.title, vo.description, vo.immediatelyAvailable)
        {
            this.Advertiser = advertiser;
            this.RealEstate = realEstate;

            if (type == AnnouncementTypeEnum.Rent) {
                RentValues = (AnnouncementRentMonetary)values; 
            } else {
                SellValues = (AnnouncementSellMonetary)values;
            }

            this.type = type; 

        }

        
    }
}
