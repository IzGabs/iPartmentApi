using API.Domain.User;
using API.src.Domain.RealState.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.ScheduledVisits.Entities.ValueObject
{
    public class ScheduledVisitsObject
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
