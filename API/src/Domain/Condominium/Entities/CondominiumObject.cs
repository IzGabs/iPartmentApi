using API.src.Domain.RealState.Entities;
using API.Domain.Location;
using API.src.Core.Swagger;
using API.src.Domain.Values;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.RealState.Models
{

    [Table("Condominios")]
    public class CondominiumObject
    {

        private CondominiumObject() { }

        public CondominiumObject(int? iD, string name,  Address location, bool academia, CondominiumMonetary Valores, List<RealStateWithCondo>? realStates )
        {
            this.ID = iD;
            this.Location = location;
            this.Academia = academia;
            this.realStates = realStates;
            this.Name = name;
            this.Valores = Valores;
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

        [Required]
        public CondominiumMonetary Valores { get; set; }

        [SwaggerIgnore]
        public List<RealStateWithCondo>? realStates { get; set;  }
    }
}