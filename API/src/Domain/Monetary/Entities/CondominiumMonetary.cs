using API.src.Core.Swagger;
using API.src.Domain.Monetary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Values
{
    [Table("CondominiumMonetary")]
    public class CondominiumMonetary : IMonetaryEntity
    {

        public CondominiumMonetary() { }
        public CondominiumMonetary(float fixValue, float? fireInsurance, float? serviceCharge)
        {
            this.montlyValue = fixValue;
            this.fireInsurence = fireInsurance;
            this.serviceCharge = serviceCharge;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        public float montlyValue { get; set; }

        public float? fireInsurence { get; set; }
        public float? serviceCharge { get; set; }

        public float valorTotal() => montlyValue + fireInsurence ?? 0 + serviceCharge ?? 0;
    }
}
