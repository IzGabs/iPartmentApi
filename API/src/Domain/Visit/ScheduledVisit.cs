using API.Domain.User;
using API.src.Domain.RealState.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Visit
{
    public class ScheduledVisit
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public RealEstateBase realState { get; set; }

        [Required]
        public UserObject visitor { get; set; }
    }
}
