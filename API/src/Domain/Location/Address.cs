using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace API.Domain.Location
{

    [Table("Enderecos")]
    public class Address
    {

        private Address() { }

        public Address(int? ID, string cep, string numero, string complemento) {
            this.ID = ID;
            this.Cep = cep;
            this.Numero = numero;
            this.Complemento = complemento;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Address)) return false;

            var thisObj = obj as Address;
            if (this.ID == thisObj.ID) return true;

            return thisObj.Cep == this.Cep &&
                thisObj.Numero == this.Numero &&
                thisObj.Complemento == this.Complemento;
        }

    }
}