using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Domain.Location
{

    [Table("Addresses")]
    public class Address
    {

        private Address() { }

        public Address(int? iD, string zipCode, string number, string city, string state, string extraInfo)
        {
            ID = iD;
            ZipCode = zipCode;
            Number = number;
            City = city;
            State = state;
            ExtraInfo = extraInfo;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string ExtraInfo { get; set; }
    }
}