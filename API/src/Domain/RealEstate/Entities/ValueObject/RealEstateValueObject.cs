using API.src.Core.Swagger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.RealState.Entities.ValueObject
{
    public class SizeRealEstate
    {

    }

    [Table("RealStates")]
    public abstract class RealEstateValueObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public int squareMeters { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }

        public int RoomWithBathroom { get; set; }
        [Required]
        public bool Furnished { get; set; }
        [Required]
        public bool AllowPets { get; set; }
        [Required]
        public bool Garage { get; set; }

        public RealEstateValueObject() { }

        protected RealEstateValueObject(int? iD, string size, int rooms, int bathrooms, int roomWithBathroom, bool furnished, bool allowPets, bool garage)
        {
            ID = iD;
            Rooms = rooms;
            Bathrooms = bathrooms;
            RoomWithBathroom = roomWithBathroom;
            Furnished = furnished;
            AllowPets = allowPets;
            Garage = garage;
        }
    }
}
