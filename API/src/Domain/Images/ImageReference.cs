using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.Images
{
    public abstract class ImageReference
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Required]
        public string createdAt { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string pathToFile { get; set; }
        [Required]
        public string type { get; set; }

        protected ImageReference() { }


        protected ImageReference(ImageReference copy) {
            this.name = copy.name;
            this.type = copy.type;
            this.createdAt = copy.createdAt;
            this.pathToFile = copy.pathToFile;
        }

        public ImageReference(string createdAt,  string name, string pathToFile, string type)
        {
            this.createdAt = createdAt;
            this.name = name;
            this.pathToFile = pathToFile;
            this.type = type;
        }

        public ImageReference( string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }
}
