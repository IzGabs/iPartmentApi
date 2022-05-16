using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Monetary.Entities
{
    [Table("AnnouncementRentMonetary")]
    public class AnnouncementRentMonetary : IMonetaryEntity
    {
        public AnnouncementRentMonetary() { }

        public AnnouncementRentMonetary(float valorFixo, float iptu = 0)
        {
            this.montlyValue = valorFixo;
            this.IPTU = iptu;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public float montlyValue { get; set; }

        public float? IPTU { get; set; }

        public float valorTotal() => montlyValue + IPTU ?? 0;
    }
}
