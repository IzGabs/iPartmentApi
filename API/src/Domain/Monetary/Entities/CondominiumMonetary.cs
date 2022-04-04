using API.src.Core.Swagger;
using API.src.Domain.Monetary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.src.Domain.Values
{
    [Table("CondominiumMonetary")]
    public class CondominiumMonetary : IMonetaryEntity
    {

        public CondominiumMonetary() { }
        public CondominiumMonetary(double fixValue, double? fireInsurance, double? serviceCharge) {
            this.montlyValue = fixValue;
            this.fireInsurence = fireInsurance;
            this.serviceCharge = serviceCharge;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        public double montlyValue { get; set; }

        public double? fireInsurence { get; set; }
        public double? serviceCharge { get; set; }

        public double valorTotal() => montlyValue + fireInsurence ?? 0 + serviceCharge ?? 0;
    }
}
