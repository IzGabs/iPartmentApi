using API.src.Core.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Images
{
    public abstract class ImageReference
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Required]
        public string createdAt { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public string pathToFile { get; set; }
        [Required]
        public string type { get; set; }

        protected ImageReference() { }

        public ImageReference( string createdAt, string description, string name, string size, string pathToFile, string type)
        {
            this.createdAt = createdAt;
            this.description = description;
            this.name = name;
            this.size = size;
            this.pathToFile = pathToFile;
            this.type = type;
        }
    }
}
