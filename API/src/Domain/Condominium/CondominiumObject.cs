using API.Domain.Location;
using API.src.Core.Swagger;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.RealState.Models
{

    [Table("Condominios")]
    public class CondominiumObject
    {

        private CondominiumObject() { }

        public CondominiumObject(int? iD, string name,  Address location, bool academia, List<RealStateObject>? realStates )
        {
            this.ID = iD;
            this.Location = location;
            this.Academia = academia;
            this.realStates = realStates;
            this.Name = name; 
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Address Location { get; set; }

        public bool Academia { get; set; }

        [SwaggerIgnore]
        public List<RealStateObject>? realStates { get; set;  }
    }
}