using API.src.Domain.Images;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.RealEstate.Entities.Aggregates
{
    public class RealEstateImages : ImageReference
    {
        [Required]
        public RealEstateBase RealEstate { get; set; }

        protected RealEstateImages() { }
        public RealEstateImages(RealEstateBase realEstate)
        {
            RealEstate = realEstate;
        }
    }
}
