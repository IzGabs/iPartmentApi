using API.Domain.User;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary;
using API.src.Domain.RealState.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.Announcement.ViewModel
{
    public class AnnouncementResponseViewModel
    {
        [Required]
        public UserObject Advertiser { get; set; }

        [Required]
        public RealEstateBase RealEstate { get; set; }

        [Required]
        public AnnouncementTypeEnum type { get; set; }

        [Required]
        public IMonetaryEntity monetary { get; set; }

        [Required]
        public int iD { get; set; }

        public DateTime createdAt { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
        
        [Required]
        public bool immediatelyAvailable { get; set; }

        


        public AnnouncementResponseViewModel(AnnouncementAggregate aggregate)
        {
            this.iD = aggregate.ID ?? 0;
            this.Advertiser = aggregate.Advertiser;
            this.RealEstate = aggregate.RealEstate;
            this.type = aggregate.type;

            this.createdAt = aggregate.createdAt;
            this.title = aggregate.title;
            this.description = aggregate.description;
            this.immediatelyAvailable = aggregate.immediatelyAvailable;

            if (type == AnnouncementTypeEnum.Rent) { this.monetary = aggregate.RentValues; }
            else { this.monetary = aggregate.SellValues; }
        }

    }
}
