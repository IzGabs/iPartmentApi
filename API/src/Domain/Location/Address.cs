using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Domain.Location
{

    [Table("Addresses")]
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }


        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string ExtraInfo { get; set; }

        public string FullAddress
        {
            get => Street + ", " + Number + ". " + ZipCode + ". " + City;
        }

        private Address() { }

        public Address(int? iD, string street, string number, string zipCode, string city, string state, string extraInfo)
        {
            ID = iD;
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
            State = state;
            ExtraInfo = extraInfo;
        }

        public void fromGeolocation(Geocoding.Location location) {
            this.Latitude = location.Latitude;
            this.Longitude = location.Longitude;
        }
    }
}