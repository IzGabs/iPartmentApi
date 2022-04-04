using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace API.Domain.Location
{

    [Table("Addresses")]
    public class Address
    {

        private Address() { }

        public Address(int? ID, string cep, string numero, string complemento) {
            this.ID = ID;
            this.ZipCode = cep;
            this.Number = numero;
            this.ExtraInfo = complemento;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Number { get; set; }

        public string ExtraInfo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Address)) return false;

            var thisObj = obj as Address;
            if (this.ID == thisObj.ID) return true;

            return thisObj.ZipCode == this.ZipCode &&
                thisObj.Number == this.Number &&
                thisObj.ExtraInfo == this.ExtraInfo;
        }

    }
}