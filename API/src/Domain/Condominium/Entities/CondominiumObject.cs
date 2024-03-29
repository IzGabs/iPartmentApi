using API.Domain.Location;
using API.src.Core.Swagger;
using API.src.Domain.RealState.Entities;
using API.src.Domain.Values;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.RealState.Models
{

    [Table("Condominiums")]
    public class CondominiumObject
    {

        private CondominiumObject() { }

        public CondominiumObject(int? iD, string name, Address location, bool academia, CondominiumMonetary Valores, List<RealEstateBase>? realStates)
        {
            this.ID = iD;
            this.Location = location;
            this.Gym = academia;
            this.realStates = realStates;
            this.Name = name;
            this.Values = Valores;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Address Location { get; set; }

        public bool Gym { get; set; }

        [Required]
        public CondominiumMonetary Values { get; set; }

        [SwaggerIgnore]
        public List<RealEstateBase>? realStates { get; set; }
    }
}