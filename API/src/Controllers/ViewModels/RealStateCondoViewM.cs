using API.src.Domain.RealState.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.ViewModels
{
    public class RealStateCondoRequest
    {
        [Required]
        public RealEstateBase realState { get; set; }

        public int condoId { get; set; }
    }
}
