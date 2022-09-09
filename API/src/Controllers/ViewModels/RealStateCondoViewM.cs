using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.ViewModels
{
    public class RealStateCondoRequest
    {
        [Required]
        public RealEstateBase realState { get; set; }

        [Required]
        public AnnouncementTypeEnum type { get; set; }

        public int condoId { get; set; }
    }
}
