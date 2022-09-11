using API.src.Core.Swagger;
using API.src.Domain.Announcement.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Monetary.Entities
{
    [Table("AnnouncementSellMonetary")]
    public class AnnouncementSellMonetary : IMonetaryEntity
    {
        public AnnouncementSellMonetary() { }

        public AnnouncementSellMonetary(float valorFixo, float iptu)
        {
            this.value = valorFixo;
            this.IPTU = iptu;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public float value { get; set; }

        [Required]
        public float? IPTU { get; set; }

        [JsonIgnore]
        public AnnouncementAggregate aggregate;

        public float valorTotal() => value;
    }
}
