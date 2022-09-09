using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers.RealState.ViewModel
{
    public class CreateViewModel
    {
        [Required]
        public RealEstateBase realEstate { get; set; }


        [Required]
        public float IPTU { get; set; }


        [Required]
        public AnnouncementTypeEnum type { get; set; }


        public int? condoId { get; set; }
    }
}
