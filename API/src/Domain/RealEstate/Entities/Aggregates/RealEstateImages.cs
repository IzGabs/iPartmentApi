using API.src.Domain.Images;
using API.src.Domain.RealState.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.RealEstate.Entities.Aggregates
{
    public class RealEstateImages : ImageReference
    {
        [Required]
        public RealEstateBase RealEstate { get; set; }

        public RealEstateImages(ImageReference imgR) : base(imgR) { }
        public RealEstateImages() { }

        public RealEstateImages(string type)
        {
            name = Guid.NewGuid().ToString();
            this.type = type;
            createdAt = DateTime.Now.ToString();
        }


        public RealEstateImages(RealEstateBase realEstate)
        {
            RealEstate = realEstate;
        }

        public RealEstateImages(ImageReference imgR, RealEstateBase realEstate) : base(imgR)
        {
            this.RealEstate = realEstate;
        }



    }
}
