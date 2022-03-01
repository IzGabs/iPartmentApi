using API.src.Core.Swagger;
using API.src.Domain.Monetary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.src.Domain.Values
{
    [Table("Valores_Condominio")]
    public class CondominiumMonetary : IMonetaryEntity
    {

        public CondominiumMonetary() { }
        public CondominiumMonetary(double fixValue, double? fireInsurance, double? serviceCharge) {
            this.valorFixo = fixValue;
            this.seguroIncendio = fireInsurance;
            this.taxaDeServico = serviceCharge;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        public double valorFixo { get; set; }

        public double? seguroIncendio { get; set; }
        public double? taxaDeServico { get; set; }

        public double valorTotal() => valorFixo + seguroIncendio ?? 0 + taxaDeServico ?? 0;
    }
}
