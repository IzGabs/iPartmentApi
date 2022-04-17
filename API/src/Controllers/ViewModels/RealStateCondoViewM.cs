using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Domain.Monetary;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.ViewModels
{
    public class RealStateCondoRequest
    {
        [Required]
        public RealStateBase realState { get; set; }

        public int condoId { get; set; }
    }
}
