using API.src.Core.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Monetary.Entities
{
    [Table("RealStateMonetary")]
    public class RealStateMonetary : IMonetaryEntity
    {
        public RealStateMonetary() { }

        public RealStateMonetary(double valorFixo, double iptu = 0) {
            this.montlyValue = valorFixo;
            this.IPTU = iptu;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public double montlyValue { get ; set ; }

        public double? IPTU { get; set; }

        public double valorTotal() => montlyValue + IPTU ?? 0;
    }
}
