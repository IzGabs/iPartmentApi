using API.src.Core.Swagger;
using API.src.Domain.Announcement.Entities;
using Newtonsoft.Json;
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

        [Required]
        public float? IPTU { get; set; }

        [JsonIgnore]
        public AnnouncementAggregate aggregate;

        public float valorTotal() => montlyValue + IPTU ?? 0;
    }
}
