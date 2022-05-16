using API.src.Core.Swagger;
using API.src.Domain.Announcement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Monetary.Entities
{
    [Table("AnnouncementSellMonetary")]
    public class AnnouncementSellMonetary : IMonetaryEntity
    {
        public AnnouncementSellMonetary() { }

        public AnnouncementSellMonetary(float valorFixo)
        {
            this.value = valorFixo;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public float value { get; set; }

        public AnnouncementAggregate aggregate;

        public float valorTotal() => value;
    }
}
